using UnityEngine;using System.Collections;public class PushableController : MonoBehaviour {    public PlayerController PlayerCon;    public Rigidbody2D RBody;
    public float Drag;
    public float Mass;	// Use this for initialization	void Start () {
        RBody.drag = 90000f;
        RBody.mass = 90000f;
        PlayerCon.Push(false);	}    //these two methods make it so that the player can only push the box while grounded,    //assuming the trigger is short and low enough.  Also triggers push animation.    //NOT HOOKED UP    void OnTriggerEnter2D ()    {
        RBody.drag = Drag;
        RBody.mass = Mass;        PlayerCon.Push(true);    }    void OnTriggerExit2D ()    {
        RBody.drag = 90000f;
        RBody.mass = 90000f;        PlayerCon.Push(false);    }}