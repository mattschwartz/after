using UnityEngine;
using After.Entities;
using After.Scene.SceneManagement;
using After.Interactable;

namespace After.Interactable
{
	public class MechanicRoomDoorConditions : InteractableConditions 
	{
    	#region Public Members
    	
    	public GameObject RequiredItem;

    	#endregion

        #region Private Members

        private bool Opened = false;

        #endregion

        public override bool OnConditionsMet()
        {
            var itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem != null && itemHeld == RequiredItem.name);

            if (playerHasItem) {
                GameObject.Find("HeldItem").SendMessage("DropItem");
                Destroy(RequiredItem);
                Opened = true;
            }

            return Opened;
        }
	}
}
