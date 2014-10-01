using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class AnimatorTransition : Transition
    {
        protected Animator Animator;

        void Start()
        {
            Animator = GetComponentInParent<Animator>();
        }

        public override bool Read(StateType fromState, StateType toState)
        {
            Animator.SetTrigger("Interact");
            Animator.SetBool("LockedState", toState == StateType.Locked);
            Animator.SetBool("UnlockedState", toState == StateType.Unlocked);
            Animator.SetBool("SpentState", toState == StateType.Spent);

            return true;
        }
    }
}
