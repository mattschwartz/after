using After.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable
{
    public class GrabbableItemController : InteractableController
    {
        #region Members

        public string ItemName;
        public string Description;

        private static float LastInteraction = 2;
        private float InteractDelay = 1;
        private GameObject Player;

        #endregion

        #region Unity Methods

        void Start()
        {
            Player = GameObject.Find("Player");
            Description = StringUtility.AorAn(ItemName, true);
        }

        void Update()
        {
            LastInteraction += Time.deltaTime;
        }

        #endregion

        public new void Interact()
        {
            if (LastInteraction >= InteractDelay) {
                ReadTransitions(StateType.Any, StateType.Any);
                Player.SendMessage("PickupItem", gameObject);
                LastInteraction = 0;
            }
        }
    }
}
