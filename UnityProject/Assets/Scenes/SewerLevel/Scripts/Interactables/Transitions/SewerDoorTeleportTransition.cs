using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SewerDoorTeleportTransition : TeleportTransition
{
    private Animator Animator;

    void Start()
    {
        Animator = GetComponentInParent<Animator>();
    }

    public override void Read(StateType fromState, StateType toState)
    {
        if (toState == StateType.Locked) {
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", 0.8f);
            Animator.SetBool("Locked", true);
            Animator.SetTrigger("TryEnter");
        } else if (toState == StateType.Unlocked) {
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", 1.5f);
            Invoke("MovePlayer", 0.8f);
            Animator.SetBool("Locked", false);
            Animator.SetTrigger("TryEnter");
        }
    }

    private void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }
}
