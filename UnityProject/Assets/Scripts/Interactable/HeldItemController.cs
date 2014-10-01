using UnityEngine;
using System;
using System.Collections;
using After.Scene.SceneManagement;
using After.Entities;

namespace After.Interactable
{
    public class HeldItemController : MonoBehaviour
    {
        #region Public Members

        public GameObject Player;

        #endregion

        #region Private Members

        private GameObject ItemHeld;

        #endregion

        void Update()
        {
            var pos = Player.transform.position;
            transform.position = new Vector2(pos.x, pos.y + 2);
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
            transform.localScale = ItemHeld.transform.localScale;
            GetComponent<SpriteRenderer>().sprite = ItemHeld.GetComponent<SpriteRenderer>().sprite;
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
            GetComponent<SpriteRenderer>().sprite = null;
            ItemHeld = null;

            SceneHandler.CurrentPlayer.ItemHeld = String.Empty;
        }
    }
}
