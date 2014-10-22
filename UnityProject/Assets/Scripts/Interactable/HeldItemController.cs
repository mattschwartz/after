﻿using UnityEngine;
using System;
using System.Collections;
using After.Scene.SceneManagement;
using After.Entities;

namespace After.Interactable
{
    public class HeldItemController : MonoBehaviour
    {
        #region Members

        public float ItemHeldSize = 100;
        public float BackpackSize = 175;
        public GameObject Player;
        public Texture BackpackTextureEmpty;
        public Texture BackpackTextureFull;

        public GameObject ItemHeld { get; private set; }
        private Texture ItemHeldTexture;

        #endregion

        void OnGUI()
        {
            if (SceneHandler.GUILock) { return; }

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, 0));
            Rect BackpackPosition = new Rect(camPos.x - BackpackSize, camPos.y - BackpackSize, BackpackSize, BackpackSize);

            if (ItemHeld != null) {
                GUI.DrawTexture(BackpackPosition, BackpackTextureFull);

                float scale = ItemHeldSize / Mathf.Max(ItemHeldTexture.width, ItemHeldTexture.height);
                float itemWidth = ItemHeldTexture.width * scale;
                float itemHeight = ItemHeldTexture.height * scale;
                Rect itemPosition = new Rect(camPos.x - itemWidth - (BackpackSize - itemWidth) / 2, camPos.y - itemHeight - (BackpackSize - itemHeight) / 2, itemWidth, itemHeight);
                GUI.DrawTexture(itemPosition, ItemHeldTexture);
            } else {
                GUI.DrawTexture(BackpackPosition, BackpackTextureEmpty);
            }
        }

        public void SetItemHeld(GameObject item)
        {
            if (ItemHeld != null) {
                DropItem();
            }

            item.transform.position = new Vector2(-5000, -5000);
            ItemHeld = item;

            ItemHeldTexture = ItemHeld.GetComponent<SpriteRenderer>().sprite.texture;
            SceneHandler.CurrentPlayer.ItemHeld = ItemHeld.name;
        }

        public void ShowItemHeld()
        {
            Debug.LogWarning("ShowItemHeld is deprecated.");
        }

        public void DropItem()
        {
            if (ItemHeld == null) {
                return;
            }

            var pos = Player.transform.position;
            ItemHeld.transform.position = new Vector2(pos.x, pos.y + 2);
            ItemHeld.rigidbody2D.velocity = Vector2.zero;
            ItemHeld.rigidbody2D.AddForce(Vector2.up * 1000f);
            ItemHeld = null;

            SceneHandler.CurrentPlayer.ItemHeld = String.Empty;
        }
    }
}
