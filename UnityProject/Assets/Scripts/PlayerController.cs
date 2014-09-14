using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Public members

    public KeyCode InteractButton = KeyCode.E;
    public KeyCode JumpButton = KeyCode.Space;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;
    
    #endregion

    #region Private members

    private bool Grounded = false;
    private bool FacingRight = true;
    private float Speed = 12f;
    private float JumpForce = 700f;
    private float GroundRadius = 0.2f;
    private Animator Animator;

    #endregion

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    #region Update

    void Update()
    {
        if (Grounded && Input.GetKeyDown(JumpButton)) {
            rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }

    void FixedUpdate()
    {
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

    #endregion

    private void IsGrounded()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask);
        // Animator.SetBool("Grounded", Grounded); // nyi
    }

    // Cheap animations
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
