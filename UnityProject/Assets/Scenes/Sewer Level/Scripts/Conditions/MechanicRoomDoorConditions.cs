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

        public override bool ConditionsMet()
        {
        	var itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
        	Debug.Log("Comparing " + itemHeld + " to " + RequiredItem.name);
            return RequiredItem != null && itemHeld == RequiredItem.name;
        }
	}
}
