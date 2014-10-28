using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scene.SceneManagement;
using After.Interactable;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    #region Members

    public KeyCode InteractButton = KeyCode.E;
    public KeyCode InspectButton = KeyCode.X;
    public KeyCode JumpButton = KeyCode.Space;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;
    public HeldItemController Backpack;
    public InspectorController InspectorController;

    //Variable multiplier for debugging the rope swing animation
    public float SwingVelMult = 10f;

    private bool PlayerLocked = false;
    private bool Grounded = false;
    private bool FacingRight = true;
    private bool Swinging = false;
    private float Speed = 7f;
    private float JumpForce = 1225f;
    private float GroundRadius = 0.2f;
    private float SwingLastX = 0f;
    private Animator Animator;
    private bool Climbing;
    private SpriteRenderer Sprite;
    private float Gravity;

    #endregion

    #region Start

    void Start()
    {
        Animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Gravity = rigidbody2D.gravityScale;
    }

    #endregion

    #region Update

    void Update()
    {
        if (PlayerLocked || Climbing) {
            return;
        }

        if (Grounded && Input.GetKeyDown(JumpButton)) {
            rigidbody2D.AddForce(Vector2.up * JumpForce);
        }

        if (Input.GetKeyDown(InteractButton)) {
            Interact();
        }

        if (Backpack && Input.GetKeyDown(InspectButton)) {
            InspectItem();
        }
    }

    void FixedUpdate()
    {
        if (PlayerLocked) {
            return;
        }

        if (Swinging)
        {
            Animator.SetFloat("Velocity", (rigidbody2D.position.x - SwingLastX) * SwingVelMult);
            print((rigidbody2D.position.x - SwingLastX) * SwingVelMult);
            SwingLastX = rigidbody2D.position.x;
        }

        if (Climbing) {
            float vMove = Input.GetAxis("Vertical");
            Animator.SetFloat("vMove", Mathf.Abs(vMove));
            rigidbody2D.velocity = new Vector2(0, vMove * Speed * 0.5f);
        } else {
            IsGrounded();

            float hMove = Input.GetAxis("Horizontal");
            Animator.SetFloat("Velocity", Mathf.Abs(hMove));
            Animator.SetFloat("vMove", rigidbody2D.velocity.y);

            rigidbody2D.velocity = new Vector2(hMove * Speed, rigidbody2D.velocity.y);

            if (hMove > 0 && !FacingRight) {
                Flip();
            } else if (hMove < 0 && FacingRight) {
                Flip();
            }
        }
        PlayerObserver.SetPlayerVel(rigidbody2D.velocity);
    }

    private void IsGrounded()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);
        Animator.SetBool("Grounded", Grounded);
    }

    // Cheap animations
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    #endregion

    #region Interact

    private void Interact()
    {
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        CircleCollider2D circle = GetComponent<CircleCollider2D>();

        Physics2D.OverlapAreaAll(bounds.min, bounds.max)
            .ToList()
            .Union(Physics2D.OverlapCircleAll(circle.bounds.center, circle.radius))
            .ToList()
            .FindAll(t => t.GetComponent("InteractableController"))
            .ForEach(t => t.gameObject.SendMessage("Interact"));
    }

    #endregion

    private void InspectItem()
    {
        if (Backpack.ItemHeld == null) { return; }
        Texture texture = Backpack.ItemHeld.GetComponent<SpriteRenderer>().sprite.texture;
        GrabbableItemController grabbableItem = Backpack.ItemHeld.GetComponent<GrabbableItemController>();
        string name = grabbableItem.ItemName;
        string description = grabbableItem.Description;

        InspectorController.InspectItem(name, description, texture);
    }

    #region Message Functions

    public bool IsLocked()
    {
        return PlayerLocked;
    }

    // Locking animation begins
    public void LockPlayer()
    {
        rigidbody2D.velocity = Vector2.zero;
        Animator.SetFloat("Velocity", 0);
        PlayerLocked = true;
    }

    // Locking animation ends
    public void FreePlayer()
    {
        PlayerLocked = false;
    }

    public void PickupItem(GameObject item)
    {
        Animator.SetTrigger("PickupItemLow");
        Backpack.SetItemHeld(item);
    }

    public void DropItem()
    {
        Backpack.DropItem();
    }

    //the variable "x" serves as the ladder's horizontal position in the on=true case
    //and the horizontal force for ladder dismount in the on=false case
    public void Climb(bool on, bool profile, float x)
    {

        if (on) {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.position = new Vector2(x, transform.position.y);
            rigidbody2D.gravityScale = 0;
            Animator.SetFloat("Velocity", 0);
            Animator.SetFloat("vMove", 0);

            if (Sprite) {
                //interspace, the space between the default and background layers, where people on ladders go
                Sprite.sortingLayerName = "Interspace";
            }
        } else {
            rigidbody2D.gravityScale = Gravity;
            if (Sprite) {
                //the normal player layer
                Sprite.sortingLayerName = "Player";
            }
            if (x != 0.0f) {
                rigidbody2D.AddForce(new Vector2(x, 200f));
                Animator.SetBool("LadderDrop", true);
            } else {
                Animator.SetBool("LadderLift", true);
            }
        }

        Climbing = on;

        Animator.SetBool("Climbing", Climbing);
        Animator.SetBool("LadderProfile", profile);
    }

    public void Push(bool push)
    {
        Animator.SetBool("Pushing", push);
    }

    public void Swing(bool swinging)
    {
        Swinging = swinging;
        Animator.SetBool("Swinging", swinging);
        SwingLastX = rigidbody2D.position.x;
    }

    public void Lift(bool lifting)
    {
        Animator.SetBool("Lifiting", lifting);
    }

    public void PlayFootstep()
    {
        // Get overlapping platform
        var collider = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);

        // Send message to platform that it needs to play footstep
        if (collider && collider.GetComponent("StepSoundController")) {
            collider.gameObject.SendMessage("PlayFootstep", 0.25F);
        }
    }

    #endregion
}
