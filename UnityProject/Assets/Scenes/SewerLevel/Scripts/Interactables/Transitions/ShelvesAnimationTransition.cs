using After.Interactable.Transitions;
using After.Interactable;

class ShelvesAnimationTransition : AnimationTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetTrigger("StealGasCan");
    }
}
