using UnityEngine;using System.Collections;using System.Collections.Generic;using After.Audio;using Assets.Scripts.Scene.SceneManagement;public class LadderController : MonoBehaviour {    //collision for any floors through which the ladder goes    //size of array set in editor    public BoxCollider2D[] FloorGates;    public PlayerController PlayerCon;    public List<AudioClip> StepClips;    public bool Profile;
    public float HandleY;
    public float TopOffY;
    public float TopOnY;    private bool Active;    private bool Entered;    private bool Top = false;    // Use this for initialization    void Start () {        //C# just made me very happy with its use of foreach        foreach (BoxCollider2D gate in FloorGates)        {            gate.enabled = true;        }        Active = false;    }    void OnTriggerEnter2D ()    {        Entered = true;    }    void OnTriggerExit2D ()    {        Entered = false;        Active = false;                foreach (BoxCollider2D gate in FloorGates)        {            gate.enabled = true;        }        PlayerCon.Climb(false, false, false, false, 0);    }        // Update is called once per frame    void Update () {        //Allows the player to mount the ladder simply by moving up or down while within the ladder's box collider        if (Entered && !Active && ((Input.GetKeyDown(KeyCode.W) && !Top) || Input.GetKeyDown(KeyCode.S) || Mathf.Abs(PlayerObserver.GetPlayerVel().y) > 20f))        {            foreach (BoxCollider2D gate in FloorGates)            {                gate.enabled = false;            }            Active = true;            PlayerCon.Climb(true, Profile, Top, false, transform.position.x);
            if (Top)
            {
                PlayerCon.SetY(HandleY);
                PlayerCon.LockPlayer();
                Invoke("FreePlayer", 1f);
                Invoke("EndDrop", 1f);
            }        }        //Allows the player to dismount the ladder simply by moving left or right        else if (Entered && Active && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))        {            Active = false;            float xForce;            if (Input.GetKeyDown(KeyCode.D)) {                xForce = 3000f;            } else {                xForce = -3000f;            }                        PlayerCon.Climb(false, false, false, false, xForce);        }        else if (Active && Top && Input.GetKey(KeyCode.W))        {            PlayerCon.Climb(true, Profile, true, true, transform.position.x);
            PlayerCon.SetY(HandleY);
            PlayerCon.LockPlayer();
            Invoke("FreePlayer", 1f);
            Invoke("EndLift", 1f);            Active = false;        }    }    public void PlayStepSound()    {        float pitch = Random.Range(0.97f, 1.03f);        AudioManager.PlayMaterialFootstepAtPoint(StepClips, pitch, transform.position);    }    public void AtTop(bool top)    {        Top = top;        if (!top)        {            PlayerCon.ResetTop();        }    }    private void FreePlayer()
    {
        PlayerCon.FreePlayer();
    }    private void EndDrop()
    {
        PlayerCon.SetY(TopOnY);
    }    private void EndLift()
    {
        PlayerCon.SetY(TopOffY);
        print("Player should have moved by now.");
    }}