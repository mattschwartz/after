using After.Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LiftLeverController : InteractableController
{
    public bool IsEnabled()
    {
        return CurrentState == StateType.Unlocked;
    }

    public void Disable()
    {
        CurrentState = StateType.Locked;
        ReadTransitions(StateType.Any, CurrentState);
    }
}
