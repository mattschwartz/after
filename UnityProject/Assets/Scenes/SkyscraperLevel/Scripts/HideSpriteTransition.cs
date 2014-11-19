using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class HideSpriteTransition : Transition
{
	public SpriteRenderer SpriteToHide;

    public override void Read(StateType fromState, StateType toState)
    {
    	SpriteToHide.enabled = false;
    }

}
