﻿using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;
using After.Journal;

namespace After.Interactable
{
    public class InspectorController : MonoBehaviour
    {
        #region Members

        public float TextWidth = 88.5f;
        public float TextureSize = 200;
        public GUITexture BlackSwatchTexture;
        public GUIStyle opaCustomStyle;
        public Color ColorOverlay;

        private bool ShowInspector;
        private string TitleText;
        private string DescriptionText;
        private KeyCode CloseButton = KeyCode.Escape;
        private Texture ItemTexture;

        public static InspectorController Instance { get; private set; }

        #endregion

        void Start()
        {
            if (Instance == null) {
                Instance = this;
                Instance.Initialize();
                DontDestroyOnLoad(this);
            } else if (this != Instance) {
                Debug.Log("Another instance of " + this.GetType().Name
                    + " exists (" + Instance + ") and is not this! "
                    + "( " + this + ") Destroying this.");
                Destroy(this.gameObject);
            }
        }

        private void Initialize()
        {
            ShowInspector = false;
            BlackSwatchTexture.pixelInset = new Rect(new Rect(0, 0, Screen.width, Screen.height));
            BlackSwatchTexture.enabled = false;
        }

        void Update()
        {
            Instance.StaticUpdate();
        }

        private void StaticUpdate()
        {
            if (!ShowInspector) { return; }

            opaCustomStyle.fixedWidth = Screen.width * (TextWidth / 100f);
            opaCustomStyle.fontSize = (int)((float)26 * (TextWidth / 100f) * ((float)Screen.width / 960f));

            if (Input.GetKeyUp(CloseButton)) {
                SceneHandler.Player.FreePlayer();
                SceneHandler.GUILock = null;
                ShowInspector = false;
                BlackSwatchTexture.enabled = false;
            }
        }

        #region Render GUI

        void OnGUI()
        {
            if (!Instance.ShowInspector) { return; }

            Instance.RenderItem();
            Instance.RenderText();
        }

        private void RenderItem() 
        {
            float itemWidth;
            float itemHeight;

            itemWidth = TextureSize;
            itemHeight = ItemTexture.height * (itemWidth / ItemTexture.width);

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            Rect itemPosition = new Rect(camPos.x - itemWidth / 2, camPos.y - itemHeight / 2, itemWidth, itemHeight);
        
            GUI.color = ColorOverlay;
            GUI.DrawTexture(itemPosition, ItemTexture);
            GUI.color = Color.white;
        }

        private void RenderText() 
        {
            float centerX = (1 - (TextWidth / 100f)) / 2;
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(centerX, 0.05f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), TitleText, opaCustomStyle);

            camPos = Camera.main.ViewportToScreenPoint(new Vector3(centerX, 0.75f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), DescriptionText, opaCustomStyle);

            camPos = Camera.main.ViewportToScreenPoint(new Vector3(centerX, 0.95f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Press Escape to close", opaCustomStyle);
        }

        #endregion

        #region Public Methods

        public void InspectItem(
            string title,
            string observations, 
            Texture itemTexture, 
            float size = 200, 
            bool addToJournal = true)
        {
            if (addToJournal) {
                AddToJournal(title, observations, itemTexture);
            }

            SceneHandler.Player.LockPlayer();
            ShowInspector = true;
            SceneHandler.GUILock = this;
            TitleText = title;
            DescriptionText = observations;
            BlackSwatchTexture.enabled = true;
            ItemTexture = itemTexture;
            TextureSize = size;
            ColorOverlay = Color.white;
        }

        private void AddToJournal(string title, string observations, Texture texture)
        {
            Entry entry = new Entry() {
                Name = title,
                Image = texture
            };

            entry.Updates.Add(observations);
            JournalController.Instance.AddEntry(entry);
        }

        #endregion
    }
}
