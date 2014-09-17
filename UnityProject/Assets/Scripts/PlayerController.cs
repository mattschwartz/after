using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scene.SceneManagement;

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

    private bool Grounded = false;
    private bool FacingRight = true;
    private float Speed = 12f;
    private float JumpForce = 700f;
    private float GroundRadius = 0.2f;
    private Animator Animator;
    private bool Climbing;
    private List<AudioSource> AudioSources;

    #endregion

    #region Start

    void Start()
    {
        Animator = GetComponent<Animator>();
        AudioSources = new List<AudioSource>(GetComponents<AudioSource>);
    }

    #endregion

    #region Update

    void Update()
    {
        if (Grounded && Input.GetKeyDown(JumpButton)) {
        	Animator.SetTrigger("Jump");
        }

        if (HeldItem != null && Input.GetKeyDown(DropButton)) {
            DropItem();
        }
    }

    public void DoJump() 
	{
        rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    void FixedUpdate()
    {
        if (Climbing) {
            float vMove = Input.GetAxis("Vertical");
            Animator.SetFloat("Velocity", Mathf.Abs(vMove));
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

    #region Message Functions

    public void PickupItem(GameObject item)
    {
        HeldItem.SendMessage("SetItemHeld", item);
    }

    public void DropItem()
    {
        HeldItem.SendMessage("DropItem");
    }

    public void IsHoldingItem(out bool result)
    {
        result = HeldItem != null;
    }

    public void Climb(bool on)
    {
        Climbing = on;
        if (on) {
            rigidbody2D.gravityScale = 0;
        } else {
            rigidbody2D.gravityScale = 8;
        }
        //NYI: animation queues
    }

    #endregion
    
        private void PlayRandomSound()
    {
        foreach (var source in AudioSources) {
            source.Stop();
        }

        System.Random ran = new System.Random();
        int index = ran.Next(4);
        var audioSource = AudioSources[index];
        audioSource.Play();
    }
}
