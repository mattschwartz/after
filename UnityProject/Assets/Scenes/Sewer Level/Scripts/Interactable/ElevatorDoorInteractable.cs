using UnityEngine;
using System.Collections;
using After.Scene.NexusControllers;
using After.Interactable;

public class ElevatorDoorInteractable : InteractableController
{
    public override void Interact()
    {
        GetComponent<Animator>().SetTrigger("Arrival");
    }
}
