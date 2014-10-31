using UnityEngine;
using System;
using System.Collections;
using After.Scene.SceneManagement;
using After.Entities;

namespace After.Interactable
{
    public class HeldItemController : MonoBehaviour
    {
        #region Members

        private float ItemHeldSize = 100;
        private float BackpackSize = 175;
        public Texture BackpackTextureEmpty;
        public Texture BackpackTextureFull;

        public GameObject ItemHeld { get; private set; }
        private Texture ItemHeldTexture;
        private Rect BackpackPosition;
        private Rect ItemPosition;

        #endregion

        void Start()
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, 0));
            BackpackPosition = new Rect(camPos.x, camPos.y, BackpackSize, BackpackSize);
        }

        void OnGUI()
        {
            if (SceneHandler.GUILock) { return; }

            if (ItemHeld != null) {
                GUI.DrawTexture(BackpackPosition, BackpackTextureFull);
                GUI.DrawTexture(ItemPosition, ItemHeldTexture);
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
            SceneHandler.PlayerItemHeld = ItemHeld.name;

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, 0));
            float scale = ItemHeldSize / Mathf.Max(ItemHeldTexture.width, ItemHeldTexture.height);
            float itemWidth = ItemHeldTexture.width * scale;
            float itemHeight = ItemHeldTexture.height * scale;
            ItemPosition = new Rect(camPos.x + (BackpackSize - itemWidth) / 2, camPos.y + (BackpackSize - itemHeight) / 2, itemWidth, itemHeight);
        }

        public void DropItem()
        {
            if (ItemHeld == null) {
                return;
            }

            var pos = SceneHandler.Player.transform.position;
            ItemHeld.transform.position = new Vector2(pos.x, pos.y + 2);
            ItemHeld.rigidbody2D.velocity = Vector2.zero;
            ItemHeld.rigidbody2D.AddForce(Vector2.up * 1000f);
            ItemHeld = null;

            SceneHandler.PlayerItemHeld = String.Empty;
        }
    }
}
