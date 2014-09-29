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
        public GameObject HeldItem;
        public GameObject RequiredItem;

        #endregion

        public override bool TestConditionsMet()
        {
            return PlayerHasItem();
        }

        public bool PlayerHasItem()
        {
            string itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem && itemHeld == RequiredItem.name);

            // Use the item, possibly destroying it
            if (playerHasItem) {
                HeldItem.SendMessage("DropItem");
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
