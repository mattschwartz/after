using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

public class TryStartGeneratorTransition : PlayerLockTransition
{
    public override void Read(StateType fromState, StateType toState)
    {
        Player.transform.position = new Vector2(transform.position.x - 4, transform.position.y);
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", LockDuration);

        PlayerAnimator.SetTrigger("ElevatorCall");
    }
}
