using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;
using System.Collections;

public class DisableParticlesTransition : Transition
{
	public ParticleSystem ParticleSystem;

	public override void Read(StateType fromState, StateType toState)
	{
        StartCoroutine(FadeEmission());
	}

    private IEnumerator FadeEmission()
    {
        while (ParticleSystem != null && ParticleSystem.emissionRate > 0.1f) {
            ParticleSystem.emissionRate = Mathf.Lerp(ParticleSystem.emissionRate, 0, Time.deltaTime);
            yield return 0;
        }

        if (ParticleSystem != null) {
            Destroy(ParticleSystem);
        }
    }
}