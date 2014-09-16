using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactable
{
    public class GrabbableItemController : InteractableController
    {
        #region Public Members

        public string ItemName; // Used for meeting conditions, possibly temp

        #endregion

        #region Private Members

        private GameObject Player;

        #endregion

        void Start()
        {
            Player = GameObject.Find("Player");
        }

        public override void Interact()
        {
            Player.SendMessage("PickupItem", gameObject);
        }
    }
}
