using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ElevatorAnimatorTransition : AnimatorTransition
{
    public override bool Read(StateType fromState, StateType toState)
    {
        Animator.SetTrigger("Arrival");
        return false;
    }
}
