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
        public GameObject RequiredItem;

        #endregion

        public override bool ConditionsMet()
        {
            return PlayerHasItem();
        }

        protected bool PlayerHasItem()
        {
            string itemHeld = SceneHandler.PlayerItemHeld;
            bool playerHasItem = (RequiredItem && itemHeld == RequiredItem.name);

            // Use the item, possibly destroying it
            if (playerHasItem) {
                BackpackController.Instance.DropItem();

                if (DestroyItemOnUse) {
                    SceneHandler.PlayerItemHeld = string.Empty;
                    Destroy(RequiredItem);
                }
            }

            return playerHasItem;
        }
    }
}
