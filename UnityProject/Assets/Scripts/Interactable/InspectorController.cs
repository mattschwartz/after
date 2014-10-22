using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;

namespace After.Interactable
{
    public class InspectorController : MonoBehaviour
    {
        #region Members

        public float TextureSize = 200;
        public KeyCode CloseButton = KeyCode.Escape;
        public GUITexture BlackSwatchTexture;
        public GUIStyle opaCustomStyle;
        public PlayerController Player;
        public Color ColorOverlay;

        private bool ShowInspector;
        private string TitleText;
        private string DescriptionText;
        private Texture ItemTexture;

        #endregion

        void Start()
        {
            ShowInspector = false;
            BlackSwatchTexture.pixelInset = new Rect(new Rect(0, 0, Screen.width, Screen.height));
            BlackSwatchTexture.enabled = false;
        }

        void Update()
        {
            if (ShowInspector && Input.GetKeyDown(CloseButton)) {
                Player.FreePlayer();
                SceneHandler.GUILock = false;
                ShowInspector = false;
                BlackSwatchTexture.enabled = false;
            }
        }

        #region Render GUI

        void OnGUI()
        {
            if (!ShowInspector) { return; }

            RenderItem();
            RenderText();
        }

        private void RenderItem() 
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.42f, 0));
            float scale = TextureSize / Mathf.Max(ItemTexture.width, ItemTexture.height);
            float itemWidth = ItemTexture.width * scale;
            float itemHeight = ItemTexture.height * scale;

            Rect itemPosition = new Rect(camPos.x - itemWidth / 2, camPos.y - itemHeight / 2, itemWidth, itemHeight);
        
            GUI.color = ColorOverlay;
            GUI.DrawTexture(itemPosition, ItemTexture);
            GUI.color = Color.white;
        }

        private void RenderText() 
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.05f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), TitleText, opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.75f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), DescriptionText, opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.95f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Press Escape to close", opaCustomStyle);
        }

        #endregion

        #region Public Methods

        public void InspectItem(string title, string description, Texture itemTexture, float size = 200)
        {
            Player.LockPlayer();
            ShowInspector = true;
            SceneHandler.GUILock = true;
            TitleText = title;
            DescriptionText = description;
            BlackSwatchTexture.enabled = true;
            ItemTexture = itemTexture;
            TextureSize = size;
            ColorOverlay = Color.white;
        }

        #endregion
    }
}
