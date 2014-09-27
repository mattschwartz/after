using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scene.SceneManagement;
using After.Interactable;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    #region Public members

    public KeyCode InteractButton = KeyCode.E;
    public KeyCode DropButton = KeyCode.X;
    public KeyCode JumpButton = KeyCode.Space;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;
    public GameObject HeldItem;

    #endregion

    #region Private members

    private bool PlayerLocked = false;
    private bool Grounded = false;
    private bool FacingRight = true;
    public float Speed = 5f;
    private float JumpForce = 700f;
    private float GroundRadius = 0.2f;
    private Animator Animator;
    private bool Climbing;
    private SpriteRenderer Sprite;

    #endregion

    #region Start

    void Start()
    {
        Animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    #endregion

    #region Update

    void Update()
    {
        if (PlayerLocked) {
            return;
        }

        if (Grounded && Input.GetKeyDown(JumpButton)) {
            rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
        
        if (Input.GetKeyDown(InteractButton)) {
            Interact();
        }

        if (HeldItem != null && Input.GetKeyDown(DropButton)) {
            DropItem();
        }
    }

    void FixedUpdate()
    {
        if (PlayerLocked) {
            return;
        }

        if (Climbing) {
            float vMove = Input.GetAxis("Vertical");
            Animator.SetFloat("vMove", Mathf.Abs(vMove));
            rigidbody2D.velocity = new Vector2(0, vMove * Speed * 0.5f);
        } else {
            IsGrounded();

            float hMove = Input.GetAxis("Horizontal");
            Animator.SetFloat("Velocity", Mathf.Abs(hMove));

            rigidbody2D.velocity = new Vector2(hMove * Speed, rigidbody2D.velocity.y);

            if (hMove > 0 && !FacingRight) {
                Flip();
            } else if (hMove < 0 && FacingRight) {
                Flip();
            }
        }
        PlayerObserver.SetPlayerVel(rigidbody2D.velocity);
    }

    #endregion

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

    #region Message Functions

    // Locking animation begins
    public void LockPlayer()
    {
        rigidbody2D.velocity = Vector2.zero;
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
        HeldItem.SendMessage("SetItemHeld", item);
    }

    public void DropItem()
    {
        HeldItem.SendMessage("DropItem");
    }

    public void Climb(bool on)
    {
        Climbing = on;
        if (on) {
            rigidbody2D.gravityScale = 0;
            if (Sprite) {
                //interspace, the space between the default and background layers, where people on ladders go
                Sprite.sortingLayerName = "Interspace";
            }
        } else {
            rigidbody2D.gravityScale = 8;
            if (Sprite) {
                //the normal player layer
                Sprite.sortingLayerName = "Player";
            }
        }

        Animator.SetBool("Climbing", Climbing);
    }

    public void PlayFootstep()
    {
        // Get overlapping platform
        var collider = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);

        // Send message to platform that it needs to play footstep
        if (collider) {
            collider.gameObject.SendMessage("PlayFootstep", 0.25F);
        }
    }

    #endregion
}
