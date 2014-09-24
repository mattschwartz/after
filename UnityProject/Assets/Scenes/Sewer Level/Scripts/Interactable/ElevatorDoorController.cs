using UnityEngine;
using System.Collections;
using After.Scene.NexusControllers;
using After.Interactable;

public class ElevatorDoorController : InteractableController
{
	private bool Spent = false;

    public override void Interact()
    {
    	if (Spent) { return; }
        GetComponent<Animator>().SetTrigger("Arrival");
    	Spent = true;
    }
}
