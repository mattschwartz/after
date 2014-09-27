using After.Scene.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable
{
    public class RequiredItemConditions : InteractableConditions
    {
        #region Public Members

        public bool DestroyItemOnUse = true;
        public GameObject RequiredItem;

        #endregion

        #region Private Members

        private GameObject HeldItemObject;

        #endregion

        void Start()
        {
            HeldItemObject = GameObject.Find("HeldItem");
        }

        public override bool TestConditionsMet()
        {
            return PlayerHasItem();
        }

        public bool PlayerHasItem()
        {
            string itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem != null && itemHeld == RequiredItem.name);

            // Use the item, possibly destroying it
            if (playerHasItem) {
                HeldItemObject.SendMessage("DropItem");
                TaskCompleted = playerHasItem;

                if (DestroyItemOnUse) {
                    SceneHandler.CurrentPlayer.ItemHeld = string.Empty;
                    Destroy(RequiredItem);
                }
            }

            return playerHasItem;
        }
    }
}
