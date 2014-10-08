using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class SmokeTransition : Transition
{
    public ParticleSystem Smoke;

    public override void Read(StateType fromState, StateType toState)
    {
        Smoke.startDelay = 1.9f;
        Smoke.Play();
    }
}
