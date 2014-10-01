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

        public override void Read(StateType currentState)
        {
            Animator.SetTrigger("Interact");
            Animator.SetBool("LockedState", currentState == StateType.Locked);
            Animator.SetBool("UnlockedState", currentState == StateType.Unlocked);
            Animator.SetBool("SpentState", currentState == StateType.Spent);
        }
    }
}
