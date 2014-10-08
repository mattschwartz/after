using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using UnityEngine;

public class FogClearerTransition : Transition
{
    public ParticleSystem FogParticles;

    public override void Read(StateType fromState, StateType toState)
    {
        Destroy(FogParticles);
    }
}
