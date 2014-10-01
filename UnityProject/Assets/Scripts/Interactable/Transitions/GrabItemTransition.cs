using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class GrabItemTransition : Transition
    {
        #region Members

        public string ItemName;

        private static float LastInteraction = 2;
        private float InteractDelay = 1;
        private GameObject Player;

        #endregion

        void Start()
        {
            Player = GameObject.Find("Player");
        }

        void Update()
        {
            LastInteraction += Time.deltaTime;
        }

        public override void Read(StateType currentState)
        {
            if (LastInteraction >= InteractDelay) {
                Player.SendMessage("PickupItem", gameObject);
                LastInteraction = 0;
            }
        }
    }
}
