using After.Interactable.Transitions;
using UnityEngine;
using After.Interactable;
using System.Collections;

 public class SoulsplosionTransition : Transition
 {
 	public Animator Animator;

 	public override void Read(StateType fromState, StateType toState)
 	{
 		Animator.SetTrigger("SoulRelease");
 	}
 }