using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class RockMoveTransition : Transition 
{
	public Rigidbody2D RockBody;
	public Vector2 AppliedForce;

	public override void Read(StateType fromState, StateType toState)
	{
		RockBody.AddForce(AppliedForce);
	}
}
