using After.Interactable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class ObservationProximityTransition : ProximityTransition
    {
        public string Observations;
        private GameObject PlayerThoughts;

        void Start()
        {
            PlayerThoughts = GameObject.Find("Player Thoughts");
        }

        public override void Read(StateType fromState, StateType toState)
        {
            PlayerThoughts.SendMessage("SetThought", Observations);
        }
    }
}
