using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class ManholeAnimationTransition : PlayerLockTransition
{
    public Animator ManholeAnimator;
    private Vector3 LeftStandingCoords = new Vector3(17.55f, -11.12682f, 0);
    private Vector3 RightStandingCoords = new Vector3(18.9f, -11.12682f, 0);

    public override void Read(StateType fromState, StateType toState)
    {
        var playerFlipped = Player.transform.localScale.x < 0;

        if (playerFlipped) {
            Player.transform.position = RightStandingCoords;
        } else {
            Player.transform.position = LeftStandingCoords;
        }

        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", LockDuration);
        Invoke("UncoverManhole", 0.2f);
        PlayerAnimator.SetTrigger("LiftManhole");
    }

    private void UncoverManhole()
    {
        ManholeAnimator.SetBool("Uncover", true);
    }
}
