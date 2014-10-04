﻿using After.Interactable;
using After.Interactable.Transitions;

public class GeneratorAnimationTransition : AnimationTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetBool("Running", true);
    }
}
