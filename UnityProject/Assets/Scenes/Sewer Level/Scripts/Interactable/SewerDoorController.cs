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
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", 1.5f);
        Invoke("MovePlayer", 0.8f);
        Animator.SetBool("Locked", false);
        Animator.SetTrigger("TryEnter");
    }

    public override void ConditionsFailed()
    {
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", 0.8f);
        Animator.SetBool("Locked", true);
        Animator.SetTrigger("TryEnter");
    }

    #region Animator Methods

    public void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }

    public void OpenDoor()
    {
        MovePlayer();
    }

    #endregion
}
