using After.Interactable.Transitions;
using UnityEngine;
using After.Interactable;

 public class SoulsplosionTransition : Transition
 {
 	public Animator Animator;

 	public override bool Read(StateType fromState, StateType toState)
 	{
 		Animator.SetTrigger("SoulRelease");

 		return true;
 	}
 }