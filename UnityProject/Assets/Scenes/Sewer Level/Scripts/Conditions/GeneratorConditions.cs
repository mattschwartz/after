using After.Interactable;
using After.Entities;
using After.Scene.SceneManagement;
using UnityEngine;

public class GeneratorConditions : RequiredItemConditions
{
	private bool HasFuel = true;
	private bool PoweredOn = false;

	void Start()
	{
		TaskCompleted = false;
	}

	public override bool TestConditionsMet() 
	{
		// Generator has enough fuel reserve the first time
		if (HasFuel) {
			// Player needs to get fuel for next time
			HasFuel = false;
            TaskCompleted = false;

			return true;
		}

        if (PlayerHasItem()) {
            HasFuel = true;
            TaskCompleted = true;
        }

		return HasFuel;
	}
}
