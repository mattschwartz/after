using After.Interactable.Transitions;
using UnityEngine;
using After.Interactable;
using After;
using System.Collections;

 public class SoulsplosionTransition : Transition
 {
 	public Animator Animator;
    public WhiteFlashController Flash;

 	public override void Read(StateType fromState, StateType toState)
 	{
 		Animator.SetTrigger("SoulRelease");
        StartCoroutine(Flash.Flash());
 	}
 }