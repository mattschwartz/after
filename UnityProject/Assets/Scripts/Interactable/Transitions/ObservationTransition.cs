using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class ObservationTransition : Transition
    {
        public string Observations;
        private GameObject PlayerThoughts;

        void Start()
        {
            PlayerThoughts = GameObject.Find("Player Thoughts");
        }

        public override bool Read(StateType fromState, StateType toState)
        {
            PlayerThoughts.SendMessage("SetThought", Observations);

            return true;
        }
    }
}
