using UnityEngine;
using After.Interactable.Transitions;
using After.Interactable;
using After.Audio;
using System.Collections;

public class StartThenLoopAudioTransition : Transition
{
    public float StartVolume = 1.0f;
    public float LoopVolume = 1.0f;
    public AudioClip StartClip;
    public AudioClip LoopClip;

    public override void Read(StateType fromState, StateType toState)
    {
        StartCoroutine(PlayClipsQueued());
    }

    private IEnumerator PlayClipsQueued()
    {
        AudioManager.PlayClipAtPoint(StartClip, 1.0f, transform.position,
            StartVolume);
        yield return new WaitForSeconds(StartClip.length);
        AudioManager.LoopClipAtPoint(LoopClip, transform.position,
            LoopVolume);
    }
}
