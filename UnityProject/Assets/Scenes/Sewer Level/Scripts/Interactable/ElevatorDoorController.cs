using UnityEngine;
using System.Collections;
using After.Scene.NexusControllers;
using After.Interactable;

public class ElevatorDoorController : InteractableController
{
    public override void Interact()
    {
        GetComponent<Animator>().SetTrigger("Arrival");
    }
}
