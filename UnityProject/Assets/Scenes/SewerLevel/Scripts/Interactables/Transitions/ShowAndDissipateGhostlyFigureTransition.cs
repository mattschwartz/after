using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class ShowAndDissipateGhostlyFigureTransition : TriggerAnimationTransition
{
    #region Members

    public SpriteRenderer Renderer;

    #endregion

    void Start()
    {
        Animator.enabled = false;
        Renderer.enabled = false;
    }

    public override void Read(StateType fromState, StateType toState)
    {
        Animator.enabled = true;
        Renderer.enabled = true;
        Animator.SetTrigger(Trigger);
    }
}
