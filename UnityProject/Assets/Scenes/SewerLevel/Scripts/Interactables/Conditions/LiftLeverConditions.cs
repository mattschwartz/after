using After.Interactable;
using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LiftLeverConditions : InteractableConditions
{
    public InteractableController GeneratorController;

    public override bool ConditionsMet()
    {
        return GeneratorController.CurrentState == StateType.Spent;
    }
}
