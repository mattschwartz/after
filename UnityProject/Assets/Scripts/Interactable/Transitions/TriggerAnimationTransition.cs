using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class TriggerAnimationTransition : Transition
    {
        public string Trigger;
        public Animator Animator;

        public override void Read(StateType fromState, StateType toState)
        {
            Animator.SetTrigger(Trigger);
        }
    }
}
