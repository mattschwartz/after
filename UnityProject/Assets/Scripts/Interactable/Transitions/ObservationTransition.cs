﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class ObservationTransition : Transition
    {
        public string Observations;
        public ObservationsController Observer;

        public override void Read(StateType fromState, StateType toState)
        {
            Observer.SetThought(Observations);
        }
    }
}
