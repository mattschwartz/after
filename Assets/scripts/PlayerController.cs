using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Public Members

    public KeyCode JumpKey;
    public KeyCode InteractKey;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;

    #endregion

    #region Private Members

    private bool Climbing = false;
    private bool FacingRight = true;
    private bool Grounded = false;
    private float Speed = 5f;
    private float JumpForce = 700f;
    private float GroundRadius = 0.2f;
    private Animator anim;

    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Called for each frame
    void Update()
    {
        if (Climbing) {
            return;
        }
        if (Grounded && Input.GetKeyDown(JumpKey)) {
            // anim.SetBool("Grounded", false); // this is when we use a blend tree
            rigidbody2D.AddForce(new Vector2(0, JumpForce));
        }
    }

    // Syncs with physics and all that good shit
    void FixedUpdate()
    {
        if (Climbing) {
            float vmove = Input.GetAxis("Vertical");
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, vmove * Speed);
        } else {
            // Check collision bounds within a circle body
            Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);
            // Set the animation to show (not) falling when the player is (not) falling
            // anim.SetBool("Ground", grounded);
            // anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

            float move = Input.GetAxis("Horizontal"); // gets default keycodes for moving left/right
            anim.SetFloat("Speed", Mathf.Abs(move));

            rigidbody2D.velocity = new Vector2(move * Speed, rigidbody2D.velocity.y);

            if (move > 0 && !FacingRight) {
                Flip();
            } else if (move < 0 && FacingRight) {
                Flip();
            }
        }
    }

    // Provides for cheap animations!
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Climb(bool addForce)
    {
        Climbing = !Climbing;
        rigidbody2D.velocity = new Vector2(0, 0);

        if (Climbing) {
            rigidbody2D.gravityScale = 0;
        } else {
            if (addForce) {
                rigidbody2D.AddForce(new Vector2(0, JumpForce));
            }

            rigidbody2D.gravityScale = 8;
        }
        anim.SetBool("Climbing", Climbing);
    }
}