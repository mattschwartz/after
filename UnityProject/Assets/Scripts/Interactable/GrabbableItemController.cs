using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using After.Interactable;

namespace Assets.Scripts.Interactable
{
    public class GrabbableItemController : InteractableController
    {
        #region Public Members

        public string ItemName; // Used for meeting conditions, possibly temp

        #endregion

        #region Private Members

        private static float LastInteraction = 2;
        private float InteractDelay = 1;
        private GameObject Player;

        #endregion

        void Start()
        {
            Player = GameObject.Find("Player");
        }

        private new void Update()
        {
            LastInteraction += Time.deltaTime;
        }

        public override void OnInteract()
        {
            if (LastInteraction >= InteractDelay) {
                Player.SendMessage("PickupItem", gameObject);
                LastInteraction = 0;
            }
        }
    }
}
