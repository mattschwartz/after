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

        public GameObject Camera;
        public GameObject Player;

        private GameObject ItemHeld;
        private SpriteRenderer Renderer;

        #endregion

        void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            var pos = Camera.transform.position;
            transform.position = new Vector2(pos.x + 5.71f, pos.y - 3.71f);
        }

        public void SetItemHeld(GameObject item)
        {
            if (ItemHeld != null) {
                DropItem();
            }

            item.transform.position = new Vector2(-5000, -5000);
            ItemHeld = item;

            SceneHandler.CurrentPlayer.ItemHeld = ItemHeld.name;
        }

        public void ShowItemHeld()
        {
            ItemHeld.transform.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Renderer.sprite = ItemHeld.GetComponent<SpriteRenderer>().sprite;
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
            Renderer.sprite = null;
            ItemHeld = null;

            SceneHandler.CurrentPlayer.ItemHeld = String.Empty;
        }
    }
}
