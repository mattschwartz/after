using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class AnimatorTransition : Transition
    {
        private Animator Animator;

        void Start()
        {
            Animator = GetComponentInParent<Animator>();
        }

        public override void Read(StateType fromState, StateType toState)
        {
            Animator.SetTrigger("Interact");
            Animator.SetBool("LockedState", fromState == StateType.Locked);
            Animator.SetBool("UnlockedState", fromState == StateType.Unlocked);
            Animator.SetBool("SpentState", fromState == StateType.Spent);
        }
    }
}
