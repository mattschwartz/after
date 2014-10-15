using System.Collections;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class SpriteTransition : Transition
    {
        public Transform TransitionTransform;
        public Sprite TransitionSprite;

        public override void Read(StateType fromState, StateType toState)
        {
            GetComponentInParent<SpriteRenderer>().sprite = TransitionSprite;
            GetComponentInParent<SpriteRenderer>().transform.position = TransitionTransform.position;
            GetComponentInParent<SpriteRenderer>().transform.localScale = TransitionTransform.localScale;
            DestroyOnRead = true;
        }
    }
}
