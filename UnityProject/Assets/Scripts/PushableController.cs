using UnityEngine;
using System.Collections;

public class PushableController : MonoBehaviour {
    public PlayerController PlayerCon;
    public Rigidbody2D RBody;

	// Use this for initialization
	void Start () {

	}

    //these two methods make it so that the player can only push the box while grounded,
    //assuming the trigger is short and low enough.  Also triggers push animation.
    //NOT YET WORKING
    void OnTriggerEnter2D ()
    {
        RBody.isKinematic = false;
        PlayerCon.Push(true);
    }

    void OnTriggerExit2D ()
    {
        RBody.isKinematic = true;
        PlayerCon.Push(false);
    }
}
