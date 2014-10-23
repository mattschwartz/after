using After.Interactable.Transitions;
using UnityEngine;
using After.Interactable;
using After;
using System.Collections;
using After.CameraTransitions;

public class SoulsplosionTransition : Transition
{
    public Animator Animator;

    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetTrigger("SoulRelease");
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(1.5f);
        TextureFader.Instance.Fade(Color.white, Color.clear, 1.5f);
    }
}