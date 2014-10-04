using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;
using System.Collections.Generic;

public class TurnOnLightsAnimationTransition : AnimationTransition
{
    public List<Animator> AreaLights;

    public override void Read(StateType fromState, StateType toState)
    {
        foreach (var light in AreaLights) {
            light.SetTrigger("PoweredOn");
        }
    }
}
