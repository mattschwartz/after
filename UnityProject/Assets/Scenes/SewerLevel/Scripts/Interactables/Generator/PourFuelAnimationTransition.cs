using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

public class PourFuelAnimationTransition : Transition
{
    public GameObject Player;
    public Animator PlayerAnimator;

    public override void Read(StateType fromState, StateType toState)
    {
        Player.transform.position = new Vector2(transform.position.x - 1.6f, transform.position.y);
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", 2.4f);
        PlayerAnimator.SetTrigger("PourFuel");
    }

    public void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }
}
