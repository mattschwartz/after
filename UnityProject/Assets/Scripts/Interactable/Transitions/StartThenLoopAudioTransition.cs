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
        Debug.Log("Playing start clip with length of: " + StartClip.length);
        AudioManager.PlayClipAtPoint(StartClip, 1.0f, transform.position,
            StartVolume);
        yield return new WaitForSeconds(StartClip.length);
        Debug.Log("Playing next clip");
        AudioManager.LoopClipAtPoint(LoopClip, transform.position,
            LoopVolume);
    }
}
