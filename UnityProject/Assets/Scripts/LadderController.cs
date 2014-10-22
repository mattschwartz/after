﻿using UnityEngine;using System.Collections;using System.Collections.Generic;using After.Audio;using Assets.Scripts.Scene.SceneManagement;public class LadderController : MonoBehaviour {    //collision for any floors through which the ladder goes    //size of array set in editor    public BoxCollider2D[] FloorGates;    public PlayerController PlayerCon;    public List<AudioClip> StepClips;    public bool Profile;    private bool Active;    private bool Entered;    // Use this for initialization    void Start () {        //C# just made me very happy with its use of foreach        foreach (BoxCollider2D gate in FloorGates)        {            gate.enabled = true;        }        Active = false;    }    void OnTriggerEnter2D ()    {        Entered = true;    }    void OnTriggerExit2D ()    {        Entered = false;        Active = false;                foreach (BoxCollider2D gate in FloorGates)        {            gate.enabled = true;        }        PlayerCon.Climb(false, false, 0);    }        // Update is called once per frame    void Update () {        //Allows the player to mount the ladder simply by moving up or down while within the ladder's box collider        if (Entered && !Active && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Mathf.Abs(PlayerObserver.GetPlayerVel().y) > 20f))        {            foreach (BoxCollider2D gate in FloorGates)            {                gate.enabled = false;            }            Active = true;            PlayerCon.Climb(true, Profile, transform.position.x);        }        //Allows the player to dismount the ladder simply by moving left or right        else if (Entered && Active && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))        {            Active = false;            float xForce;            if (Input.GetKeyDown(KeyCode.D)) {                xForce = 3000f;            } else {                xForce = -3000f;            }                        PlayerCon.Climb(false, false, xForce);        }    }    public void PlayStepSound()    {        float pitch = Random.Range(0.97f, 1.03f);        AudioManager.PlayMaterialFootstepAtPoint(StepClips, pitch, transform.position);    }}