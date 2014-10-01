﻿using After.Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LiftLeverController : InteractableController
{

    public void Disable()
    {
        CurrentState = StateType.Locked;
        ReadTransition(StateType.Any, CurrentState);
    }
}