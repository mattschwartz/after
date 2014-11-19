using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class DropBoulderTransition : Transition 
{
	public Rigidbody2D BoulderBody;

    public override void Read(StateType fromState, StateType toState)
    {
    	BoulderBody.gravityScale = 8;
    }
}
