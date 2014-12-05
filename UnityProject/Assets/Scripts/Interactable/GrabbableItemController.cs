﻿using After.Journal;
using After.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable
{
    public class GrabbableItemController : InteractableController
    {
        #region Members

        public float WidthOnInspection = 200f;
        public string ItemName;
        public string Description;
        public Texture JournalImage;

        private static float LastInteraction = 2;
        private float InteractDelay = 1;
        private GameObject Player;

        #endregion

        #region Unity Methods

        void Start()
        {
            Player = GameObject.Find("Player");
            if (string.IsNullOrEmpty(Description)) {
                Description = StringUtility.AorAn(ItemName, true);
            }
        }

        void Update()
        {
            LastInteraction += Time.deltaTime;
        }

        #endregion

        public new void Interact()
        {
            if (LastInteraction >= InteractDelay) {
                ReadTransitions(StateType.Any, StateType.Any);
                Player.SendMessage("PickupItem", gameObject);
                LastInteraction = 0;

                Entry entry = new Entry() {
                    Name = ItemName,
                    Image = JournalImage == null ? GetComponent<SpriteRenderer>().sprite.texture : JournalImage
                };

                entry.Updates.Add(Description);

                JournalController.Instance.AddEntry(entry);
            }
        }
    }
}
