using System.Collections;
using UnityEngine;

namespace After.Interactable.Transitions
{
	public class SpriteTransition : Transition
	{
		public Sprite TransitionSprite;

		public override void Read(StateType fromState, StateType toState)
		{
			GetComponentInParent<SpriteRenderer>().sprite = TransitionSprite;
			GetComponentInParent<SpriteRenderer>().transform.localScale = new Vector3(1, 1, 1);
            DestroyOnRead = true;
		}
	}
}
