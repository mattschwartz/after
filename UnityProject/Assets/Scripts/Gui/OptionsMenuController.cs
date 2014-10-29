using System.Collections;
using After.Audio;
using UnityEngine;
using After.Scene.SceneManagement;
using After.Journal;

namespace After.Gui
{
    public class OptionsMenuController : MonoBehaviour
    {
        #region Members

        public float hSliderValue;
        public GUIStyle opaCustomStyle;
        public GUIStyle SliderStyle;
        public GUIStyle SliderThumbStyle;
        public GUIStyle JournalStyle;
        public GUIStyle MainMenuStyle;
        public Texture MenuBackgroundTexture;

        private bool Visible = false;
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

            if (!Visible) { return; }

            Resize();
        }

        private void ProcessKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Visible = !Visible;

                if (Visible) {
                    Show();
                } else {
                    Hide();
                }
            }
        }

        private void Show()
        {
            Visible = true;
            SceneHandler.GUILock = true;
            Time.timeScale = 0;
        }

        private void Hide()
        {
            Visible = false;
            SceneHandler.GUILock = false;
            Time.timeScale = 1;
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
                y = camPos.y - 149,
                width = 146,
                height = 149
            };

            screenCoords = new Vector3(1, 1, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            MainMenuBounds = new Rect {
                x = camPos.x - 108,
                y = camPos.y - 116,
                width = 108,
                height = 116
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

            RenderSlider();
            RenderText();
            RenderButtons();
        }

        private void RenderSlider()
        {
            hSliderValue = GUI.HorizontalSlider(SoundSliderBounds,
                hSliderValue, 0, 100, SliderStyle, SliderThumbStyle);
            AudioListener.volume = hSliderValue / 100f;   
        }

        private void RenderText()
        {
            GUI.Label(TitleBounds, "Game Options", opaCustomStyle);
            GUI.Label(LabelBounds, "Game Volume:", opaCustomStyle);
        }

        private void RenderButtons()
        {
            if (GUI.Button(MainMenuBounds, GUIContent.none, MainMenuStyle)) {
                Debug.Log("Returning to main menu.");
            }

            if (GUI.Button(JournalIconBounds, GUIContent.none, JournalStyle)) {
                Hide();
                JournalController.Instance.Show();
            }
        }
    }
}
