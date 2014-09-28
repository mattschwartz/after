using UnityEngine;
using System.Collections;
using After.Interactable;

public class ElevatorDoorConditions : InteractableConditions
{
    #region Public Members

    public LiftLeverController LiftController;

    #endregion

    public override bool TestConditionsMet()
    {
        return LiftController.IsEnabled();
    }
}
