using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class ResumePlayingFansTransition : Transition 
{
	public InteractableController ServerController;
	public AudioSource LoopSource;

    public override void Read(StateType fromState, StateType toState)
    {
    	if (ServerController.CurrentState == StateType.Unlocked) {
	    	LoopSource.Play();
    	}
    }
}
