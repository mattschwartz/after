using After.Interactable;
using After.Entities;
using After.Scene.SceneManagement;
using UnityEngine;

public class GeneratorConditions : RequiredItemConditions
{
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

        if (PlayerHasItem()) {
            PlayerNeedsFuel = false;
        }

		return !PlayerNeedsFuel;
	}
}
