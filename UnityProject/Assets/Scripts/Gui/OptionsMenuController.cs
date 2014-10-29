using System.Collections;
using After.Audio;
using UnityEngine;
using After.Scene.SceneManagement;

namespace After.Gui
{
    public class OptionsMenuController : MonoBehaviour
    {
        #region Members

        public float hSliderValue;
        public GUIStyle opaCustomStyle;
        public GUIStyle SliderStyle;
        public GUIStyle SliderThumbStyle;
        public Texture JournalIconTexture;
        public Texture MainMenuIconTexture;
        public Texture MenuBackgroundTexture;

        private bool Visible = false;
        private KeyCode kcOkay = KeyCode.Return;
        private KeyCode kcCancel = KeyCode.Escape;
        private Rect MenuBackgroundBounds;
        private Rect SoundSliderBounds;
        private Rect JournalIconBounds;
        private Rect MainMenuBounds;
        private Rect TitleBounds;
        private Rect LabelBounds;

        #endregion

        void Start()
        {
            hSliderValue = AudioListener.volume * 100f;
            Resize();
        }

        void Update()
        {
            if (!Visible && SceneHandler.GUILock) { return; }

            ProcessKeyboard();
            ProcessMouse();

            if (!Visible) { return; }

            Resize();
            AudioManager.SetVolume(hSliderValue / 100f);
        }

        private void ProcessKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Visible = !Visible;
                SceneHandler.GUILock = Visible;
                Time.timeScale = Visible ? 0 : 1;
            }
        }

        private void ProcessMouse()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }

            Vector3 mouse = Input.mousePosition;
            mouse.y = Screen.height - mouse.y;

            if (JournalIconBounds.Contains(mouse)) {
                Debug.Log("Opening journal.");
            } else if (MainMenuBounds.Contains(mouse)) {
                Debug.Log("Returning to main menu.");
            }
        }

        private void Resize()
        {
            var screenCoords = new Vector3(0.5f, 0.5f, 0);
            var camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            SoundSliderBounds = new Rect {
                x = camPos.x,
                y = camPos.y,
                width = 175,
                height = 25
            };

            screenCoords = new Vector3(0, 1, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            JournalIconBounds = new Rect {
                x = camPos.x,
                y = camPos.y - JournalIconTexture.height,
                width = JournalIconTexture.width,
                height = JournalIconTexture.height
            };

            screenCoords = new Vector3(1, 1, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            MainMenuBounds = new Rect {
                x = camPos.x - MainMenuIconTexture.width,
                y = camPos.y - MainMenuIconTexture.height,
                width = MainMenuIconTexture.width,
                height = MainMenuIconTexture.height
            };

            screenCoords = new Vector3(0.5f, 0.1f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            TitleBounds = new Rect {
                x = camPos.x,
                y = camPos.y,
                width = 0,
                height = 0
            };

            screenCoords = new Vector3(0.4f, 0.5f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            LabelBounds = new Rect {
                x = camPos.x,
                y = camPos.y,
                width = 0,
                height = 0
            };

            screenCoords = new Vector3(0.4f, 0.5f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            MenuBackgroundBounds = new Rect {
                x = 0,
                y = 0,
                width = Screen.width,
                height = Screen.height
            };
        }

        void OnGUI()
        {
            if (!Visible) { return; }

            GUI.DrawTexture(MenuBackgroundBounds, MenuBackgroundTexture);

            hSliderValue = GUI.HorizontalSlider(SoundSliderBounds,
                hSliderValue, 0, 100, SliderStyle, SliderThumbStyle);

            GUI.Label(TitleBounds, "Game Options", opaCustomStyle);
            GUI.Label(LabelBounds, "Game Volume:", opaCustomStyle);
            GUI.DrawTexture(MainMenuBounds, MainMenuIconTexture);
            GUI.DrawTexture(JournalIconBounds, JournalIconTexture);
        }
    }
}
