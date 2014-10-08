using UnityEngine;
using After.Interactable.Transitions;
using After.Interactable;
using After.Audio;
using System.Collections;

public class StartGeneratorAudio : Transition
{
    public float GeneratorStartVolume = 1.0f;
    public float GeneratorLoopVolume = 1.0f;
    public AudioClip GeneratorStart;
    public AudioClip GeneratorLoop;

    public override void Read(StateType fromState, StateType toState)
    {
        StartCoroutine(PlayClipsQueued());
    }

    private IEnumerator PlayClipsQueued()
    {
        AudioManager.PlayClipAtPoint(GeneratorStart, 1.0f, transform.position,
            GeneratorStartVolume);
        yield return new WaitForSeconds(GeneratorStart.length);
        AudioManager.LoopClipAtPoint(GeneratorLoop, transform.position,
            GeneratorLoopVolume);
    }
}
