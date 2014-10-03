using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;
using System.Collections;

public class DisableSoulParticlesTransition : Transition
{
	public ParticleSystem ParticleSystem;

	public override void Read(StateType fromState, StateType toState)
	{
		ParticleSystem.emissionRate = 0;
		DestroyOnRead = true;
	}
}