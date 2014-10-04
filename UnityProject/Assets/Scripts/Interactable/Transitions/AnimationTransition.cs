using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public abstract class AnimationTransition : Transition
    {
        protected Animator Animator;

        void Start()
        {
            Animator = GetComponentInParent<Animator>();
        }
    }
}
