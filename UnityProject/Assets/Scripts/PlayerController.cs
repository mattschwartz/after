using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scene.SceneManagement;
using After.Interactable;
using System.Linq;
using After.Scene.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Members

    public float Speed = 7f;
    public float JumpForce = 1225f;
    public KeyCode InteractButton = KeyCode.E;
    public KeyCode JumpButton = KeyCode.Space;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;

    // Variable multiplier for debugging the rope swing animation
    public float SwingVelMult = 10f;

    private bool PlayerLocked = false;
    private bool Grounded = false;
    private bool FacingRight = true;
    private bool Swinging = false;
    private float GroundRadius = 0.2f;
    private float SwingLastX = 0f;
    private Animator Animator;
    public bool Climbing { get; private set; }
    private SpriteRenderer Sprite;
    private float Gravity;
    private float JumpCD;  //cooldown on player jumping

    #endregion

    #region Start

    void Start()
    {
        Animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Gravity = rigidbody2D.gravityScale;
        JumpCD = 0f;
    }

    #endregion

    #region Update

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer) {
            return;
        }

        if (PlayerLocked || Climbing) {
            return;
        }

        if (JumpCD < 0f && Grounded && Input.GetKeyDown(JumpButton)) {
            rigidbody2D.AddForce(Vector2.up * JumpForce);
            JumpCD = .5f;
        }

        if (Input.GetKeyDown(InteractButton)) {
            Interact();
        }
    }

    void FixedUpdate()
    {
        if (SceneHandler.OnMobile) {
            IsGrounded();
            if (Swinging) {
                Animator.SetFloat("Velocity", (rigidbody2D.position.x - SwingLastX) * SwingVelMult);
                PlayerObserver.SetPlayerVel(new Vector2((rigidbody2D.position.x - SwingLastX) * SwingVelMult, 0));
                SwingLastX = rigidbody2D.position.x;
            } else {
                PlayerObserver.SetPlayerVel(rigidbody2D.velocity);
            }
            return;
        }

        JumpCD -= Time.deltaTime;
        if (PlayerLocked) {
            return;
        }

        if (Swinging) {
            Animator.SetFloat("Velocity", (rigidbody2D.position.x - SwingLastX) * SwingVelMult);
            PlayerObserver.SetPlayerVel(new Vector2((rigidbody2D.position.x - SwingLastX) * SwingVelMult, 0));
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
        if (!Swinging)
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

    public void Interact()
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

    #region Movement Interface (for Mobile)

    public void Move(float hMove)
    {
        if (Climbing) { return; }

        if (PlayerLocked) {
            Animator.SetFloat("Velocity", 0);
            Animator.SetFloat("vMove", rigidbody2D.velocity.y);
            return; 
        }

        Animator.SetFloat("Velocity", Mathf.Abs(hMove));
        Animator.SetFloat("vMove", rigidbody2D.velocity.y);

        rigidbody2D.velocity = new Vector2(hMove * Speed, rigidbody2D.velocity.y);

        if (hMove > 0 && !FacingRight) {
            Flip();
        } else if (hMove < 0 && FacingRight) {
            Flip();
        }
    }

    public void Climb(float vMove)
    {
        if (PlayerLocked || !Climbing) { return; }

        Animator.SetFloat("vMove", Mathf.Abs(vMove));
        rigidbody2D.velocity = new Vector2(0, vMove * Speed * 0.5f);
    }

    public void Jump()
    {
        if (!Grounded || Climbing) { return; }

        rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    public void Swing()
    {
        Animator.SetFloat("Velocity", (rigidbody2D.position.x - SwingLastX) * SwingVelMult);
        PlayerObserver.SetPlayerVel(new Vector2((rigidbody2D.position.x - SwingLastX) * SwingVelMult, 0));
        SwingLastX = rigidbody2D.position.x;
    }

    #endregion

    // Deprecated :(
    private void InspectItem()
    {
        if (BackpackController.Instance.ItemHeld == null) { return; }

        GrabbableItemController grabbableItem = BackpackController.Instance
            .ItemHeld.GetComponent<GrabbableItemController>();
        string name = grabbableItem.ItemName;
        string description = grabbableItem.Description;

        Texture journalImage = grabbableItem.JournalImage == null
            ? BackpackController.Instance.ItemHeld
            .GetComponent<SpriteRenderer>().sprite.texture
            : grabbableItem.JournalImage;

        InspectorController.Instance.InspectItem(name, description, journalImage);
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
        BackpackController.Instance.SetItemHeld(item);
    }

    public void DropItem()
    {
        BackpackController.Instance.DropItem();
    }

    //the variable "x" serves as the ladder's horizontal position in the on=true case
    //and the horizontal force for ladder dismount in the on=false case
    public void Climb(bool on, bool profile, bool top, bool up, float xForce)
    {

        if (on) {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.gravityScale = 0;
            Animator.SetFloat("Velocity", 0);
            Animator.SetFloat("vMove", 0);
            Animator.SetBool("LadderDrop", top && !up);
            Animator.SetBool("LadderLift", top && up);

            if (Sprite) {
                //interspace, the space between the default and background layers, where people on ladders go
                Sprite.sortingLayerName = "Interspace";
                Sprite.sortingOrder = 100;
            }
        } else {
            rigidbody2D.gravityScale = Gravity;
            if (Sprite) {
                //the normal player layer
                Sprite.sortingLayerName = "Player";
                Sprite.sortingOrder = 0;
            }

            if (xForce != 0.0f) {
                rigidbody2D.AddForce(new Vector2(xForce, 200f));
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

    public void PlayFootstep()
    {
        // Get overlapping platform
        var collider = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);

        // Send message to platform that it needs to play footstep
        if (collider && collider.GetComponent("StepSoundController")) {
            collider.gameObject.SendMessage("PlayFootstep", 0.25F);
        }
    }

    public void ResetTop()
    {
        Animator.SetBool("LadderLift", false);
        Animator.SetBool("LadderDrop", false);
    }

    public void SetPos(float x, float y)
    {
        if (y == -9000f)
            transform.position = new Vector2(x, transform.position.y);
        else
            transform.position = new Vector2(x, y);
    }

    public GameObject GetObj()
    {
        return gameObject;
    }

    #endregion
}
