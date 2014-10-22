using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using After.Audio;
using After.CameraTransitions;
using After.Scene.SceneManagement;

namespace After.Journal
{
    public class JournalController : MonoBehaviour
    {
        #region Members

        public float Size = 500;

        public KeyCode PreviousPageKey = KeyCode.LeftArrow;
        public KeyCode NextPageKey = KeyCode.RightArrow;
        public KeyCode JournalKey = KeyCode.J;
        public KeyCode CloseJournal = KeyCode.Escape;
        public AudioClip JournalPageFlipClip;
        public AudioClip OpenJournalClip;
        public PlayerController Player;
        public Texture JournalBackground;
        public GUITexture FadedBackgroundTexture;
        public GUIStyle opaCustomStyle;
        public GUIStyle IndexEntryStyle;

        private bool Visible = false;
        private int EntryIndex = 0;
        private List<Entry> Entries;
        private Rect PreviousPageBounds;
        private Rect NextPageBounds;
        private Rect JournalIndexBounds;

        #endregion

        #region Start

        void Start()
        {
            DontDestroyOnLoad(this);

            Entries = new List<Entry>();
            Entries.Add(new Entry("Index", "", null));

            FadedBackgroundTexture.transform.position = Vector3.zero;
            FadedBackgroundTexture.pixelInset = new Rect(new Rect(0, 0, Screen.width, Screen.height));
            FadedBackgroundTexture.enabled = false;
            DefineClickableRegions();
        }

        private void DefineClickableRegions()
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.10f, 0.79f, 0));
            PreviousPageBounds = new Rect(camPos.x, camPos.y, 160, 50);

            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.66f, 0.81f, 0));
            NextPageBounds = new Rect(camPos.x, camPos.y, 125, 35);

            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.15f, 0.08f, 0));
            JournalIndexBounds = new Rect(camPos.x, camPos.y, 75, 30);
        }
        
        #endregion

        #region Update

        void Update()
        {
            if (!Player.IsLocked() && Input.GetKeyDown(JournalKey)) {
                Show();
            }

            if (Input.GetKeyDown(CloseJournal)) {
                Close();
            }

            if (!Visible) { return; }

            ProcessMouse();

            if (Input.GetKeyDown(PreviousPageKey)) {
                TurnPage(-1);
            } else if (Input.GetKeyDown(NextPageKey)) {
                TurnPage(1);
            }
        }

        private void ProcessMouse()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }

            Vector3 mouse = Input.mousePosition;
            mouse.y = Screen.height - mouse.y;

            if (Input.GetMouseButtonDown(0) && PreviousPageBounds.Contains(mouse)) {
                TurnPage(-1);
            } else if (Input.GetMouseButtonDown(0) && NextPageBounds.Contains(mouse)) {
                TurnPage(1);
            } else if (Input.GetMouseButtonDown(0) && JournalIndexBounds.Contains(mouse)) {
                Debug.Log("Going to index page");
            }
        }

        #endregion

        #region Journal Interact Methods

        private void Show()
        {
            if (Visible) { return; }

            Visible = true;
            SceneHandler.GUILock = true;
            FadedBackgroundTexture.enabled = true;
            Player.LockPlayer();
            AudioManager.PlayClipAtPoint(OpenJournalClip, Vector2.zero);
        }

        private void Close()
        {
            if (!Visible) { return; }

            Visible = false;
            SceneHandler.GUILock = false;
            FadedBackgroundTexture.enabled = false;
            Player.FreePlayer();
            AudioManager.PlayClipAtPoint(OpenJournalClip, Vector2.zero);
        }

        private void TurnPage(int direction)
        {
            int oldIndex = EntryIndex;

            if (direction < 0) {
                --EntryIndex;
                Debug.Log("Previous page");
            } else {
                ++EntryIndex;
                Debug.Log("Next page");
            }

            EntryIndex = Mathf.Clamp(EntryIndex, 0, Entries.Count);

            if (oldIndex != EntryIndex) {
                AudioManager.PlayClipAtPoint(JournalPageFlipClip, Vector2.zero);
            }
        }

        #endregion

        #region Render GUI

        void OnGUI()
        {
            DefineClickableRegions();
            if (!Visible) { return; }

            RenderBackground();
            RenderText();
        }

        private void RenderBackground()
        {
            float scale = Size / Mathf.Max(JournalBackground.width, JournalBackground.height);
            float width = JournalBackground.width * scale;
            float height = JournalBackground.height * scale;

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
            Rect pos = new Rect(camPos.x - width / 2, camPos.y - height / 2, width, height);

            GUI.DrawTexture(pos, JournalBackground);
        }

        private void RenderText()
        {
            RenderEntry();

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.95f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Press Escape to close", opaCustomStyle);

            // dbg
            GUI.Box(PreviousPageBounds, GUIContent.none);
            GUI.Box(NextPageBounds, GUIContent.none);
            GUI.Box(JournalIndexBounds, GUIContent.none);
        }

        private void RenderEntry()
        {
            if (EntryIndex == 0 || EntryIndex >= Entries.Count) {
                RenderIndex();
                return;
            }

            Entry entry = Entries[EntryIndex];

            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.05f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), entry.Name, opaCustomStyle);
            camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.75f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), entry.Description, opaCustomStyle);
        }

        private void RenderIndex()
        {
            var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.46f, 0.16f, 0));
            GUI.Label(new Rect(camPos.x, camPos.y, 0, 0), "Index", IndexEntryStyle);

            if (Entries.Count == 1) {
                GUI.Label(new Rect(camPos.x, camPos.y + 35, 0, 0), "No entries", IndexEntryStyle);
                return;
            }

            for (int i = 1; i < Mathf.Min(Entries.Count, 8); ++i) {
                GUI.Label(new Rect(camPos.x, camPos.y + i * 35, 0, 0), Entries[i].Name, IndexEntryStyle);
            }
        }

        #endregion

        #region Public Methods

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        #endregion
    }
}
