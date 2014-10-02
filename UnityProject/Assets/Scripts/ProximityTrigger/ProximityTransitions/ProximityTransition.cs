using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.ProximityTrigger.ProximityTransitions
{
    public abstract class ProximityTransition : Transition
    {
        public bool PlayOnEnter = true;
        public bool PlayOnRemain = true;
        public bool PlayOnExit = true;

        public bool Legible(StateType currentState, TriggerType triggerType)
        {
            switch (triggerType) {
                case TriggerType.Enter:
                    return PlayOnEnter;
                case TriggerType.Remain:
                    return PlayOnRemain;
                case TriggerType.Exit:
                    return PlayOnExit;
            }

            return false;
        }
    }
}
