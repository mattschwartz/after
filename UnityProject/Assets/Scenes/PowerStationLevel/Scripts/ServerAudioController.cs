using UnityEngine;
using After.Interactable.Transitions;
using After.Interactable;
using System.Collections;

public class ServerAudioController : Transition
{
    public float StartVolume = 1.0f;
    public float LoopVolume = 1.0f;
    public AudioSource StartSource;
    public AudioSource LoopSource;

    public override void Read(StateType fromState, StateType toState)
    {
    	StartSource.volume = StartVolume;
    	LoopSource.volume = LoopVolume;
        StartCoroutine(PlayClipsQueued());
    }

    private IEnumerator PlayClipsQueued()
    {
        StartSource.Play();
        yield return new WaitForSeconds(StartSource.clip.length * 0.9f);
        StartSource.Stop();
        LoopSource.Play();
    }
}
