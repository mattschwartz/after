using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GeneratorAnimationTransition : AnimationTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetBool("PoweredOn", toState != StateType.Locked);
    }
}
