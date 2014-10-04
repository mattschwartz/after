using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;

public class ElevatorCallAnimationTransition : PlayerLockTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Player.transform.position = new Vector2(transform.position.x - 2.43f, Player.transform.position.y);
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", LockDuration);

        PlayerAnimator.SetTrigger("ElevatorCall");
    }
}
