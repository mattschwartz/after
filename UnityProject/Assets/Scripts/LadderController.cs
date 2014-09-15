﻿using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour {

    //collision for any floors through which the ladder goes
    //size of array set in editor
    public BoxCollider2D[] FloorGates;
    public GameObject PlayerObject;
    private bool Active;
    private bool Entered;

	// Use this for initialization
	void Start () {
        //C# just made me very happy with its use of foreach
        foreach (BoxCollider2D gate in FloorGates)
        {
            gate.enabled = true;
        }
        Active = false;
	}

    void OnTriggerEnter2D ()
    {
        Entered = true;
    }

    void OnTriggerExit2D ()
    {
        Entered = false;
        
        foreach (BoxCollider2D gate in FloorGates)
        {
            gate.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Allows the player to mount the ladder simply by moving up or down while within the ladder's box collider
	    if (Entered && !Active && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
        {
            foreach (BoxCollider2D gate in FloorGates)
            {
                gate.enabled = false;
            }
            Active = true;

            PlayerObject.SendMessage("Climb", true);

            //centers the character on the ladder
            PlayerObject.transform.position = new Vector2(transform.position.x, PlayerObject.transform.position.y);
        }

        //Allows the player to dismount the ladder simply by moving left or right
        if (Entered && Active && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))
        {
            Active = false;
            PlayerObject.SendMessage("Climb", false);
        }
	}
}
