using After.Scene.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Conditions
{
    public class RequiredItemConditions : InteractableConditions
    {
        #region Members

        public bool DestroyItemOnUse = true;
        public GameObject HeldItem;
        public GameObject RequiredItem;

        #endregion

        public override bool ConditionsMet()
        {
            string itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem && itemHeld == RequiredItem.name);

            // Use the item, possibly destroying it
            if (playerHasItem) {
                HeldItem.SendMessage("DropItem");

                if (DestroyItemOnUse) {
                    SceneHandler.CurrentPlayer.ItemHeld = string.Empty;
                    Destroy(RequiredItem);
                }
            }

            return playerHasItem;
        }
    }
}
