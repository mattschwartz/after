using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLockedConditions : RequiredItemConditions
{
    public GeneratorInteractableController GeneratorController;

    public override bool ConditionsMet()
    {
        if (PlayerHasItem()) {
            GeneratorController.FuelLevel++;
        }

        return GeneratorController.FuelLevel > 0;
    }
}
