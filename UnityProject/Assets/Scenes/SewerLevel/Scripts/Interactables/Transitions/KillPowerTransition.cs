﻿using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KillPowerTransition : Transition
{
    public GeneratorInteractableController GeneratorController;
    public BoxCollider2D PowerOutageTrigger;

    public override bool Read(After.Interactable.StateType fromState, After.Interactable.StateType toState)
    {
        if (GeneratorController.FuelLevel <= 1) {
            PowerOutageTrigger.enabled = true;
            Destroy(gameObject);
        }

        return false;
    }
}