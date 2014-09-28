using UnityEngine;
using System.Collections;
using After.Interactable;

public class LiftLeverConditions : InteractableConditions
{

    #region Public Members

    public GeneratorInteractableController GeneratorController;

    #endregion

    public override bool TestConditionsMet()
    {
        return GeneratorController.IsPoweredOn();
    }
}
