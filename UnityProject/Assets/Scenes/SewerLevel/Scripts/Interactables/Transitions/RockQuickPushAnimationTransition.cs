using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class RockQuickPushAnimationTransition : Transition 
{
    public float Duration;
    public string Boolean;
    public Animator PlayerAnimator;
    public PlayerController Player;

    public override void Read(StateType fromState, StateType toState)
    {
        StartCoroutine(QuickPush());
    }

    private IEnumerator QuickPush()
    {
        Player.LockPlayer();
        PlayerAnimator.SetBool(Boolean, true);
        yield return new WaitForSeconds(Duration);
        PlayerAnimator.SetBool(Boolean, false);
        Player.FreePlayer();
    }
}
