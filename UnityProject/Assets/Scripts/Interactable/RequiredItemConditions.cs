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
        public bool DestroyItemOnUse = true;
        public GameObject RequiredItem;

        private bool CompletedTask = false;

        public bool PlayerHasItem()
        {
            // Player has already completed this task 
            if (CompletedTask) {
                return true;
            }

            var itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem != null && itemHeld == RequiredItem.name);

            CompletedTask = playerHasItem;

            if (playerHasItem) {
                GameObject.Find("HeldItem").SendMessage("DropItem");

                if (DestroyItemOnUse) {
                    Destroy(RequiredItem);
                }
            }


            return playerHasItem;
        }

        public override bool OnConditionsMet()
        {
            return PlayerHasItem();
        }
    }
}
