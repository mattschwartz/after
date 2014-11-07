using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

namespace After.Interactable 
{
	public class ItemGrabTransition : Transition
	{
		public GrabbableItemController GrabbableItem;

        void Start()
        {
            GrabbableItem.GetComponent<SpriteRenderer>().enabled = false;
            GrabbableItem.GetComponent<BoxCollider2D>().enabled = false;
            GrabbableItem.transform.position = new Vector2(-5000, -5000);
        }

        public override void Read(StateType fromState, StateType toState)
        {
        	BackpackController.Instance.SetItemHeld(GrabbableItem.gameObject);
            GrabbableItem = null;
        }

	}
}
