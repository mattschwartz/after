using UnityEngine;
using System.Collections;
using After.Scene.NexusControllers;

public class SewerDoorController : NexusController
{
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Door is unlocked and player can walk through it
    public override void OnInteract()
    {
        Animator.SetBool("Locked", false);
        Animator.SetTrigger("TryEnter");
    }

    public void OpenDoor()
    {
        MovePlayer();
    }

    public override void AfterPlayerMoved()
    {

    }

    public override void OnConditionsFailed()
    {
        Animator.SetBool("Locked", true);
        Animator.SetTrigger("TryEnter");
    }
}
