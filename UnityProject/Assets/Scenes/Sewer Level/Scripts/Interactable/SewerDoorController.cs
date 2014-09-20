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

    public override void OnInteract()
    {
        Animator.SetBool("Locked", false);
        Animator.SetTrigger("TryEnter");

        // Figure out how to sync this up with player walkthrough animation
        MovePlayer();
    }

    public override void OnConditionsFailed()
    {
        Animator.SetBool("Locked", true);
        Animator.SetTrigger("TryEnter");
    }
}
