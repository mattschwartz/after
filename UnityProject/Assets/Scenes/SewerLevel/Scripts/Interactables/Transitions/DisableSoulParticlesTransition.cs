using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;

public class DisableSoulParticlesTransition : Transition
{
	public ParticleSystem ParticleSystem;

	public override bool Read(StateType fromState, StateType toState)
	{
		ParticleSystem.emissionRate = 0;
		return false;
	}
}