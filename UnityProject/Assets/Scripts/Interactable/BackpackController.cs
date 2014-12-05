using UnityEngine;
using System;
using System.Collections;
using After.Scene.SceneManagement;
using After.Entities;

namespace After.Interactable
{
    public class BackpackController : MonoBehaviour
    {
        #region Members

        private float ItemHeldSize = 100;
        private float BackpackSize = 175;
        public Texture BackpackTextureEmpty;

        public GameObject ItemHeld { get; private set; }
        private Texture ItemHeldTexture;
        private Rect BackpackPosition;
        private Rect ItemPosition;

        public static BackpackController Instance { get; private set; }

        #endregion

        void Start()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(this);
            } else if (this != Instance) {
                Debug.Log("Another instance of " + GetType().Name
                    + " exists (" + Instance + ") and is not this! "
                    + "( " + this + ") Destroying this.");
                Destroy(gameObject);
            }
        }

        private void Resize()
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, 0));
            float scale = Screen.width / 960f;

            BackpackPosition = new Rect(camPos.x, camPos.y, BackpackSize * scale, BackpackSize * scale);
        }

        void OnGUI()
        {
            if (SceneHandler.GUILock) { return; }

            Instance.Resize();
            Instance.StaticOnGui();
        }

        private void StaticOnGui()
        {
            GUI.DrawTexture(BackpackPosition, BackpackTextureEmpty);

            if (ItemHeld != null) {
                GUI.DrawTexture(ItemPosition, ItemHeldTexture);
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
            float scale = Screen.width / 960f;
            float itemWidth = ItemHeldTexture.width * scale;
            float itemHeight = ItemHeldTexture.height * scale;
            ItemPosition = new Rect(camPos.x + (BackpackSize * scale - itemWidth) / 2, camPos.y + (BackpackSize * scale - itemHeight) / 2, itemWidth, itemHeight);
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
