using After.Interactable;
using After.Interactable.Transitions;

public class LiftLeverAnimationTransition : AnimationTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetBool("Enabled", true);
    }
}
