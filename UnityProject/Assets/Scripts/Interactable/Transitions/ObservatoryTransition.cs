using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class ObservatoryTransition : Transition
    {
        public string Observations;
        private GameObject PlayerThoughts;

        void Start()
        {
            PlayerThoughts = GameObject.Find("Player Thoughts");
        }

        public override void Read(StateType currentState)
        {
            PlayerThoughts.SendMessage("SetThought", Observations);
        }
    }
}
