using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GeneratorUnlockedConditions : RequiredItemConditions
{
    public GeneratorInteractableController GeneratorController;

    public override bool ConditionsMet()
    {
        // Consume fuel if player has it
        if (PlayerHasItem()) {
            GeneratorController.FuelLevel++;
        }

        // Can't leave unlocked state
        return true;
    }
}
