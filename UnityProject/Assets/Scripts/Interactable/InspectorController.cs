using UnityEngine;
using System.Collections;

namespace After.Interactable
{
    public class InspectorController : MonoBehaviour
    {
        #region Members

        public float ItemHeldSize = 200;

        public KeyCode CloseButton = KeyCode.Escape;
        public GUITexture BlackSwatchTexture;
        public GUIStyle opaCustomStyle;

        private bool ShowInspector;
        private Texture ItemTexture;
        private GrabbableItemController InspectedItem;

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
                ShowInspector = false;
                InspectedItem = null;
                BlackSwatchTexture.enabled = false;
            }
        }

        void OnGUI()
        {
            if (!ShowInspector) { return; }

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.05f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), InspectedItem.ItemName, opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.75f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), InspectedItem.Description, opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.95f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Press Escape to close", opaCustomStyle);

            float scale = ItemHeldSize / Mathf.Max(ItemTexture.width, ItemTexture.height);
            float itemWidth = ItemTexture.width * scale;
            float itemHeight = ItemTexture.height * scale;

            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            Rect itemPosition = new Rect(camPos.x - itemWidth/2, camPos.y - itemHeight/2, itemWidth, itemHeight);
            GUI.DrawTexture(itemPosition, ItemTexture);
        }

        public void InspectItem(GameObject item)
        {
            ShowInspector = true;
            InspectedItem = item.GetComponent<GrabbableItemController>();
            BlackSwatchTexture.enabled = true;
            ItemTexture = item.GetComponent<SpriteRenderer>().sprite.texture;
        }
    }
}
