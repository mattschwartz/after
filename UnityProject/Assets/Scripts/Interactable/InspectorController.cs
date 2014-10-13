using UnityEngine;
using System.Collections;

namespace After.Interactable
{
    public class InspectorController : MonoBehaviour
    {
        #region Members

        public bool ShowInspector = true;
        public KeyCode CloseButton = KeyCode.X;
        public GrabbableItemController InspectedItem;
        public PlayerController Player;
        public GUITexture BlackSwatchTexture;
        public GUIStyle opaCustomStyle;

        #endregion

        void Update()
        {
            if (Input.GetKeyDown(CloseButton)) {
                ShowInspector = false;
                InspectedItem = null;
                BlackSwatchTexture.enabled = false;
            }
        }

        void OnGUI()
        {
            if (!ShowInspector) { return; }
            
            Rect pos = new Rect(0, 0, Screen.width, Screen.height);
            BlackSwatchTexture.pixelInset = new Rect(pos);
            BlackSwatchTexture.enabled = true;

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.05f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Some Rebar", opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.75f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Some metal used for reinforcing concrete that can be used for pyring, now.", opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.95f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Press X to close", opaCustomStyle);
        }

        public void InspectItem(GrabbableItemController Item)
        {
            ShowInspector = true;
            InspectedItem = Item;
        }
    }
}
