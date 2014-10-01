using After.Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GeneratorInteractableController : InteractableController
{
    #region Members

    public int FuelLevel = 1;

    public bool PoweredOn { get; private set; }
    private Animator Animator;

    #endregion

    void Start()
    {
        PoweredOn = true;
        Animator = GetComponent<Animator>();
        Animator.SetBool("Running", true);
    }

    public void ExpendFuel()
    {
        FuelLevel--;
        SetPoweredOn(FuelLevel > 0);
    }

    public void SetPoweredOn(bool on)
    {
        PoweredOn = on;
        CurrentState = PoweredOn ? StateType.Unlocked : StateType.Locked;
        Animator.SetBool("Running", PoweredOn);
    }
}
