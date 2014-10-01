using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GeneratorPowerTransition : AnimatorTransition
{
    public GeneratorInteractableController GeneratorController;

    public override bool Read(StateType fromState, StateType toState)
    {
        GeneratorController.SetPoweredOn(toState != StateType.Locked);
        Animator.SetBool("Running", toState != StateType.Locked);

        return true;
    }
}
