using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ElevatorConditions : InteractableConditions
{
    public LiftLeverController LiftLever;

    public override bool ConditionsMet()
    {
        return LiftLever.IsEnabled();
    }
}
