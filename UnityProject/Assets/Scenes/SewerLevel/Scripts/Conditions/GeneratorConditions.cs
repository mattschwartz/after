using After.Interactable;
using After.Entities;
using After.Scene.SceneManagement;
using UnityEngine;

public class GeneratorConditions : RequiredItemConditions
{
	private bool HasFuel = true;
	private bool PoweredOn = false;
    public GeneratorInteractableController Generator;
    
	void Start()
	{
		TaskCompleted = false;
	}

	public override bool TestConditionsMet() 
	{
		bool result = false;
		// Generator has enough fuel reserve the first time
		if (HasFuel) {
			result = true;
			// Player needs to get fuel for next time
			HasFuel = false;
            TaskCompleted = false;
		}

        if (PlayerHasItem()) {
        	result = true;
            Generator.DestroyAudioTrigger();
            HasFuel = true;
            TaskCompleted = true;
        }

		return Generator.IsPoweredOn() || result;
	}
}
