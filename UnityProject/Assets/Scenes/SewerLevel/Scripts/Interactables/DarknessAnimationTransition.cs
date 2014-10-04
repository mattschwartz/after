using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

public class DarknessAnimationTransition : Transition
{
    public Animator DarknessAnimator;

    public override void Read(StateType fromState, StateType toState)
    {
        DarknessAnimator.SetTrigger("LightsOn");
    }
}
