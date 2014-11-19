using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class PauseOrPlayClipTransition : Transition 
{
    public float OldStartVolume;
    public float OldLoopVolume;
	public AudioSource StartSource;
	public AudioSource LoopSource;
	
    public override void Read(StateType fromState, StateType toState)
    {
        StartSource.volume = Flop(StartSource.volume, 0, OldStartVolume);
        LoopSource.volume = Flop(LoopSource.volume, 0, OldLoopVolume);
    }

    private float Flop(float a, float b, float c)
    {
        if (a == b) { return c; }
        return b;
    }
}
