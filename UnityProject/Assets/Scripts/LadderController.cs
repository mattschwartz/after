using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using After.Audio;
using Assets.Scripts.Scene.SceneManagement;

public class LadderController : MonoBehaviour {

    //collision for any floors through which the ladder goes
    //size of array set in editor
    public BoxCollider2D[] FloorGates;
    public PlayerController PlayerCon;
    public List<AudioClip> StepClips;
    public bool Profile;
    public float HandleY;
    public float TopOffY;
    public float TopOnY;
    public bool Blocked;  //not to be modified in-editor

    private bool Active;
    private bool Entered;
    private bool Top = false;

    // Use this for initialization
    void Start () {
        //C# just made me very happy with its use of foreach
        foreach (BoxCollider2D gate in FloorGates)
        {
            gate.enabled = true;
        }
        Active = false;
        Blocked = false;
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject != PlayerCon.GetObj())
            return;
        Entered = true;
    }

    void OnTriggerExit2D ()
    {
        if (!Active)
            Entered = false;
        Active = false;
        
        foreach (BoxCollider2D gate in FloorGates)
        {
            gate.enabled = true;
        }

        PlayerCon.Climb(false, false, false, false, 0);
    }

    #region Mobile stuff - avert your eyes, Tyler

    public bool LadderUp;
    public bool LadderDown;
    public bool LadderLeft;
    public bool LadderRight;

    #endregion

    // Update is called once per frame
    void Update () {
        if (Application.platform != RuntimePlatform.Android ||
            Application.platform != RuntimePlatform.IPhonePlayer) {
            LadderUp = Input.GetKeyDown(KeyCode.W);
            LadderDown = Input.GetKeyDown(KeyCode.S);
            LadderLeft = Input.GetKeyDown(KeyCode.A);
            LadderRight = Input.GetKeyDown(KeyCode.D);
        }
        
        //Allows the player to mount the ladder simply by moving up or down while within the ladder's box collider
        //After determining issue, put " || Mathf.Abs(PlayerObserver.GetPlayerVel().y) > 20f" back at end of if-statement
        if (!Blocked && Entered && ((!Active && ((LadderUp && !Top) || LadderDown)) || Mathf.Abs(PlayerObserver.GetPlayerVel().y) > 10f))
        {
            foreach (BoxCollider2D gate in FloorGates)
            {
                gate.enabled = false;
            }
            Active = true;

            PlayerCon.Climb(true, Profile, Top, false, 0);
            if (Top)
            {
                PlayerCon.SetPos(transform.position.x, HandleY);
                PlayerCon.LockPlayer();
                Invoke("FreePlayer", .5f);
                Invoke("EndDrop", .5f);
            }
            else
            {
                PlayerCon.SetPos(transform.position.x, -9000f);
            }
        }

        //Allows the player to dismount the ladder simply by moving left or right
        else if (Entered && Active && (LadderLeft || LadderRight))
        {
            Active = false;
            Entered = false;

            float xForce;
            if (LadderRight) {
                xForce = 3000f;
            } else {
                xForce = -3000f;
            }
            
            PlayerCon.Climb(false, false, false, false, xForce);
        }

        else if (Active && Top && LadderUp)
        {
            PlayerCon.Climb(true, Profile, true, true, transform.position.x);
            PlayerCon.LockPlayer();
            PlayerCon.SetPos(transform.position.x, HandleY);
            Invoke("FreePlayer", .5f);
            Invoke("EndLift", .5f);
            Active = false;
            Entered = false;
        }
    }

    public void PlayStepSound()
    {
        float pitch = Random.Range(0.97f, 1.03f);

        AudioManager.PlayMaterialFootstepAtPoint(StepClips, pitch, transform.position);
    }

    public void AtTop(bool top)
    {
        Top = top;

        if (!top)
        {
            PlayerCon.ResetTop();
        }
    }

    private void FreePlayer()
    {
        PlayerCon.FreePlayer();
    }

    private void EndDrop()
    {
        PlayerCon.SetPos(transform.position.x, TopOnY);
    }

    private void EndLift()
    {
        PlayerCon.SetPos(transform.position.x, TopOffY);
    }
}
