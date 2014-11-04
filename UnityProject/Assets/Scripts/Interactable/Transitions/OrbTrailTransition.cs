using System.Collections.Generic;
using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

public class OrbTrailTransition : Transition
{

	public string Trigger;
	public List<Animator> Orbs;

	public override void Read(StateType fromState, StateType toState)
	{
		foreach (var orb in Orbs) {
			orb.SetTrigger(Trigger);
		}
	}
}
