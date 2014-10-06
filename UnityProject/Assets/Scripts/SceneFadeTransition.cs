using After.Interactable.Transitions;
using After.Interactable;
using After;
using UnityEngine;

public class SceneFadeTransition : PlayerLockTransition
{
	public SceneFaderController Fader;

    public override void Read(StateType fromState, StateType toState)
    {
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", LockDuration);

        StartCoroutine(Fader.FadeOut());
    }
}