using After.Interactable;
using After.Interactable.Transitions;
using System.Collections;
using UnityEngine;

class ElevatorAnimatorTransition : AnimatorTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetTrigger("Arrival");
        DestroyOnRead = true;
    }
}
