using UnityEngine;
using System.Collections;
using After.Scene.NexusControllers;

public class ElevatorDoorInteractable : NexusController
{
    public override void OnInteract()
    {
        GetComponent<Animator>().SetTrigger("Arrival");
    }
}
