using After.Interactable;
using After.Entities;
using After.Scene.SceneManagement;
using UnityEngine;

public class GeneratorConditions : InteractableConditions
{

	public GameObject RequiredItem;

	private bool HasFuel = true;
	private bool PlayerNeedsFuel = false;

	public override bool ConditionsMet() 
	{
		// Generator has enough fuel reserve the first time
		if (HasFuel) {
			// Player needs to get fuel for next time
			HasFuel = false;
			PlayerNeedsFuel = true;
			return true;
		}

		var itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
        bool playerHasItem = (RequiredItem != null && itemHeld == RequiredItem.name);

        if (playerHasItem) {
        	// Player has found the fuel!
            GameObject.Find("HeldItem").SendMessage("DropItem");
            Destroy(RequiredItem);
            PlayerNeedsFuel = false;
        }

		return !PlayerNeedsFuel;
	}
}
