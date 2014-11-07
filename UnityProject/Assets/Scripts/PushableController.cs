using UnityEngine;
using System.Collections;

public class PushableController : MonoBehaviour {
    public PlayerController PlayerCon;
    public Rigidbody2D RBody;
    public BoxCollider2D Trigger;
    public float Drag;
    public float Mass;
    private bool Falling;

	// Use this for initialization
	void Start () {
        RBody.drag = 90000f;
        RBody.mass = 90000f;
	}

    //these two methods make it so that the player can only push the box while grounded,
    //assuming the trigger is short and low enough.  Also triggers push animation.
    void OnTriggerEnter2D ()
    {
        RBody.drag = Drag;
        RBody.mass = Mass;
        if (Trigger.isTrigger)
            PlayerCon.Push(true);
    }

    void OnTriggerExit2D ()
    {
        RBody.drag = 90000f;
        RBody.mass = 90000f;
        PlayerCon.Push(false);
    }

    void Update ()
    {
        if (RBody.velocity.y != 0f)
        {
            Falling = true;
            RBody.drag = 0f;
        }
        else if (Falling)
        {
            Falling = false;
            RBody.drag = 90000f;
        }
    }
}
