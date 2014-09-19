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
        public GameObject RequiredItem;

        public bool PlayerHasItem()
        {
            var itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
            bool playerHasItem = (RequiredItem != null && itemHeld == RequiredItem.name);

            if (playerHasItem) {
                GameObject.Find("HeldItem").SendMessage("DropItem");
                Destroy(RequiredItem);
            }

            return playerHasItem;
        }

        public override bool ConditionsMet()
        {
            return PlayerHasItem();
        }
    }
}
