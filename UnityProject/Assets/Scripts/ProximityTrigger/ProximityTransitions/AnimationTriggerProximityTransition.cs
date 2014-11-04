using After.Interactable;
using UnityEngine;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class AnimationTriggerProximityTransition : ProximityTransition
    {
        public string Trigger;
        public Animator Animator;

        public override void Read(StateType fromState, StateType toState)
        {
            Animator.SetTrigger(Trigger);
        }
    }
}
