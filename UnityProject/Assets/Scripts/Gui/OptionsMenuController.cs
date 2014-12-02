using System.Collections;
using After.Audio;
using UnityEngine;
using After.Scene.SceneManagement;
using After.Journal;
using System.Collections.Generic;

namespace After.Gui
{
    public class OptionsMenuController : MonoBehaviour
    {
        #region Members

        public float ClickClipVolume;
        public GUIStyle TitleLabelStyle;
        public GUIStyle VolumeLabelStyle;
        public GUIStyle SliderStyle;
        public GUIStyle SliderThumbStyle;
        public GUIStyle JournalStyle;
        public GUIStyle MainMenuStyle;
        public Texture MenuBackgroundTexture;
        public AudioClip ClickClip;

        private bool Visible = false;
        private float hSliderValue;
        private Rect MenuBackgroundBounds;
        private Rect SoundSliderBounds;
        private Rect JournalBounds;
        private Rect MainMenuBounds;
        private Rect TitleBounds;
        private Rect LabelBounds;
        private List<float> Notes;

        #endregion

        void Start()
        {
            hSliderValue = AudioListener.volume * 100f;
            Resize();

            Notes = new List<float>() {
                0.05946309435905f,
                0.12246204830885f,
                0.1892071150019f,
                0.2599210498937f,
                0.3348398541685f,
                0.4142135623711f,

                -0.05946309435905f,
                -0.12246204830885f,
                -0.1892071150019f,
                -0.2599210498937f,
                -0.3348398541685f,
                -0.4142135623711f
            };
        }

        private void PlayRandomClick()
        {
            float pitch = 1 + (Notes[Random.Range(0, Notes.Count - 1)]);
            AudioManager.PlayClipAtPoint(ClickClip, pitch, transform.position, ClickClipVolume);
        }

        void Update()
        {
            if (SceneHandler.GUILock != this
                && SceneHandler.GUILock != null) {
                return;
            }

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
            SceneHandler.GUILock = this;
            Time.timeScale = 0;
        }

        private void Hide()
        {
            Visible = false;
            SceneHandler.GUILock = null;
            Time.timeScale = 1;
        }

        private void Resize()
        {
            float scale = ((float)Screen.width / 960f);
            float w = 194 * scale;
            float h = 70 * (w / 194);
            float th = 35f * scale;

            TitleLabelStyle.fontSize = (int)((float)24 * scale);
            VolumeLabelStyle.fontSize = (int)((float)21 * scale);

            SliderThumbStyle.fixedWidth = 30f * scale;
            SliderThumbStyle.fixedHeight = th;

            var screenCoords = new Vector3(0.5f, 0.36f, 0);
            Vector3 camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            SoundSliderBounds = new Rect {
                x = camPos.x - w / 2,
                y = camPos.y - th / 2,
                width = w,
                height = th
            };

            screenCoords = new Vector3(0.5f, 0.5f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            MainMenuBounds = new Rect {
                x = camPos.x - w / 2,
                y = camPos.y - h / 2,
                width = w,
                height = h
            };

            screenCoords = new Vector3(0.5f, 0.65f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            JournalBounds = new Rect {
                x = camPos.x - w / 2,
                y = camPos.y - h / 2,
                width = w,
                height = h
            };

            screenCoords = new Vector3(0.5f, 0.1f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            TitleBounds = new Rect {
                x = camPos.x,
                y = camPos.y,
                width = 0,
                height = 0
            };

            screenCoords = new Vector3(0.5f, 0.3f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            LabelBounds = new Rect {
                x = camPos.x,
                y = camPos.y,
                width = 0,
                height = 0
            };

            screenCoords = new Vector3(0.5f, 0.5f, 0);
            camPos = Camera.main.ViewportToScreenPoint(screenCoords);

            h = 0.90f * Screen.height;
            w = MenuBackgroundTexture.width * (h / MenuBackgroundTexture.height);

            MenuBackgroundBounds = new Rect {
                x = camPos.x - w / 2,
                y = camPos.y - h / 2,
                width = w,
                height = h
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
            GUI.Label(TitleBounds, "Game Options", TitleLabelStyle);
            GUI.Label(LabelBounds, "Game Volume:", VolumeLabelStyle);
        }

        private void MenuButton_Click()
        {
            PlayRandomClick();
            Hide();
            Application.LoadLevel("TitleScreenLevel");
        }

        private void JournalButton_Click()
        {
            PlayRandomClick();
            Hide();
            JournalController.Instance.Show();
        }

        private void RenderButtons()
        {
            if (GUI.Button(MainMenuBounds, GUIContent.none, MainMenuStyle)) {
                MenuButton_Click();
            }

            if (GUI.Button(JournalBounds, GUIContent.none, JournalStyle)) {
                JournalButton_Click();
            }
        }
    }
}
