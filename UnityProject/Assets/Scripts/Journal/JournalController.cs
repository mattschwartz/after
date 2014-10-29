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

        private static bool Created = false;

        public bool ShowToast = false;
        public float ToastDuration = 3;
        public float ToastDurationTracker;
        public string ToastText = "Journal Updated";

        public float PercentSize = 88.5f;
        public float EntryImageSize = 200;
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
        public GUIStyle EntryStyle;

        private bool Visible = false;
        private int EntryIndex = 0;
        private float Scale;
        private List<Entry> Entries;
        private Rect JournalBounds;
        private Rect PreviousPageBounds;
        private Rect NextPageBounds;
        private Rect JournalIndexBounds;

        #endregion

        #region Start

        void Awake()
        {
            if (!Created) {
                DontDestroyOnLoad(this);
                Created = true;}
        }

        void Start()
        {
            Entries = new List<Entry>();
            Entries.Add(new Entry("Index", "", null));

            FadedBackgroundTexture.transform.position = Vector3.zero;
            FadedBackgroundTexture.pixelInset = new Rect(new Rect(0, 0, 
                Screen.width, Screen.height));
            FadedBackgroundTexture.enabled = false;
            DefineClickableRegions();
        }

        /// <summary>Determine the size of the rectangles of the clickable 
        /// regions on the screen. 
        /// </summary>
        private void DefineClickableRegions()
        {
            Scale = (PercentSize / 100f);
            EntryStyle.fontSize = (int)(21f * Scale);

            PreviousPageBounds = GetRelativeByBounds(JournalBounds, 0.046f, 
                0.83f, 180 * Scale, 45 * Scale);

            NextPageBounds = GetRelativeByBounds(JournalBounds, 0.68f, 0.835f, 
                140 * Scale, 35 * Scale);

            JournalIndexBounds = GetRelativeByBounds(JournalBounds, 0.109f, 0.05f,
                77 * Scale, 34 * Scale);
        }

        /// <summary>Creates a <c>Rect</c> that is scaled according to the 
        /// specified <paramref name="bounds" />bounds parameter.
        /// </summary>
        /// <param name="bounds">The containing <c>Rect</c> object.</param>
        /// <param name="scaleX">The x-scale in percent form of the returned
        /// <c>Rect</c> object.</param>
        /// <param name="scaleY">The y-scale in percent form of the returned
        /// <c>Rect</c> object.</param>
        /// <param name="width">The width of the returned <c>Rect</c> object,
        /// used also for centering the return.</param>
        /// <param name="height">The height of the returned <c>Rect</c> object,
        /// used also for centering the return.</param>
        /// <param name="centered">If true, will center the returned <c>Rect</c>
        /// object. Defaults to false.</param>
        /// <returns>Returns a <c>Rect</c> object that has been scaled according
        /// to the supplied <paramref name="bounds"/>bounds parameter.</returns>
        private Rect GetRelativeByBounds(
            Rect bounds, 
            float scaleX, 
            float scaleY, 
            float width = 0, 
            float height = 0, 
            bool centered = false) 
        {
            Rect result;

            if (centered) {
                result = new Rect {
                    x = bounds.x + bounds.width * scaleX - width / 2,
                    y = bounds.y + bounds.height * scaleY - height / 2,
                    width = width,
                    height = height
                };
            } else {
                result = new Rect {
                    x = bounds.x + bounds.width * scaleX,
                    y = bounds.y + bounds.height * scaleY,
                    width = width,
                    height = height
                };
            }

            return result;
        }
        
        #endregion

        #region Update

        void Update()
        {
            if (!Visible && SceneHandler.GUILock) { return; }

            DefineClickableRegions();
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

        /// <summary>
        /// </summary>
        private void ProcessMouse()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }

            Vector3 mouse = Input.mousePosition;
            mouse.y = Screen.height - mouse.y;

            if (PreviousPageBounds.Contains(mouse)) {
                TurnPage(-1);
            } else if (NextPageBounds.Contains(mouse)) {
                TurnPage(1);
            } else if (JournalIndexBounds.Contains(mouse)) {
                EntryIndex = 0;
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

        /// <summary>Turn page either left or right, but the method needs to be
        /// reworked.
        /// </summary>
        /// <param name="direction">Negative direction turns left, positive
        /// direction turns right.</param>
        private void TurnPage(int direction)
        {
            if (direction < 0 && EntryIndex > 0) {
                --EntryIndex;
                AudioManager.PlayClipAtPoint(JournalPageFlipClip, Vector2.zero);
            } else if (direction > 0 && EntryIndex < Entries.Count - 1) {
                ++EntryIndex;
                AudioManager.PlayClipAtPoint(JournalPageFlipClip, Vector2.zero);
            }
        }

        #endregion

        #region Render GUI

        void OnGUI()
        {
            Toast();

            if (!Visible) { return; }

            RenderBackground();
            RenderText();
        }

        /// <summary>Handles rendering the Toast prompt to the screen, stopping 
        /// it if the duration has exceeded the Toast duration.
        /// </summary>
        private void Toast() 
        {
            if (!ShowToast) { return; }
            if (ToastDurationTracker <= 0) {
                ShowToast = false;
            }

            var screenCoords = new Vector3(0.105f, 0.93f, 0);
            var camPos = Camera.main.ViewportToScreenPoint(screenCoords);
            var labelCoords = new Rect(camPos.x, camPos.y, 0, 0);

            GUI.Label(labelCoords, ToastText, opaCustomStyle);
            ToastDurationTracker -= Time.deltaTime;
        }

        /// <summary>Renders the Journal background texture to the screen.
        /// </summary>
        private void RenderBackground()
        {
            float screenScale = (PercentSize / 100f) * Mathf.Max(Screen.width, Screen.height);
            float scale = screenScale / Mathf.Max(JournalBackground.width, JournalBackground.height);

            float width = JournalBackground.width * scale;
            float height = JournalBackground.height * scale;

            var screenCoords = new Vector3(0.5f, 0.5f, 0);
            var camPos = Camera.main.ViewportToScreenPoint(screenCoords);
            JournalBounds = new Rect(camPos.x - width / 2, camPos.y - height / 2, width, height);

            GUI.DrawTexture(JournalBounds, JournalBackground);
        }

        /// <summary>Render the text of the Journal entry and other UI prompts
        /// for the journal.
        /// </summary>
        private void RenderText()
        {
            if (EntryIndex == 0 || EntryIndex >= Entries.Count) {
                RenderIndex();
            } else {
                RenderEntry();
            }

            var screenCoords = new Vector3(0.5f, 0.9f, 0);
            var camPos = Camera.main.ViewportToScreenPoint(screenCoords);
            var labelCoords = new Rect(camPos.x, camPos.y, 0, 0);
            GUI.Label(labelCoords, "Press Escape to close", opaCustomStyle);

            // dbg
            GUI.Box(PreviousPageBounds, GUIContent.none);
            GUI.Box(NextPageBounds, GUIContent.none);
            GUI.Box(JournalIndexBounds, GUIContent.none);
        }

        /// <summary>Renders the currently selected journal entry or index if
        /// no valid entry is selected.
        /// </summary>
        private void RenderEntry()
        {
            Entry entry = Entries[EntryIndex];

            Rect pos = GetRelativeByBounds(JournalBounds, 0.46f, 0.11f, 
                210 * Scale, 0);

            GUI.Label(pos, entry.Name, EntryStyle);
            pos.y += 31 * Scale;
            GUI.Label(pos, entry.Description, EntryStyle);

            RenderEntryImage(entry.Image);
        }

        /// <summary>Renders a <c>Texture</c> of the entry to the Journal.
        /// </summary>
        /// <param name="image">The <c>Texture</c> of the entry image to be 
        /// drawn on the Journal.</param>
        private void RenderEntryImage(Texture image)
        {
            float scale = EntryImageSize / Mathf.Max(image.width, image.height);
            float itemWidth = image.width * scale;
            float itemHeight = image.height * scale;

            Rect bounds = GetRelativeByBounds(JournalBounds, 0.21f, 0.5f, 
                itemWidth * Scale, itemHeight * Scale, true);

            GUI.DrawTexture(bounds, image);
        }

        /// <summary>Renders the index page for the Journal that lists the 
        /// entries.
        /// </summary>
        private void RenderIndex()
        {
            Rect bounds = GetRelativeByBounds(JournalBounds, 0.46f, 0.11f);
            GUI.Label(bounds, "Index", EntryStyle);

            if (Entries.Count == 1) {
                bounds.y += 31 * Scale;
                GUI.Label(bounds, "No entries", EntryStyle);
                return;
            }

            for (int i = 1; i < Mathf.Min(Entries.Count, 8); ++i) {
                bounds.y += 31 * Scale;
                GUI.Label(bounds, Entries[i].Name, EntryStyle);
            }
        }

        #endregion

        #region Add Journal Entry

        /// <summary>Public accessor method for adding entries to the Journal.
        /// </summary>
        /// <param name="enry">The entry to be added to the Journal.</param>
        public void AddEntry(Entry entry)
        {
            if (!UniqueAdd(entry)) { return; }
            // Toast the new entry
            ToastDurationTracker = ToastDuration;
            ShowToast = true;
        }

        /// <summary>Inserts an entry into the journal only if there isn't 
        /// already an entry in the journal.
        /// </summary>
        /// <param name="entry">The entry to be added</param>
        /// <returns>Returns true if the entry was added and should toast the
        /// new entry</returns>
        private bool UniqueAdd(Entry entry)
        {
            foreach (var jEntry in Entries) {
                if (jEntry.Name == entry.Name) {
                    jEntry.Description = entry.Description;
                    jEntry.Image = entry.Image;
                    return false;
                }
            }

            Entries.Add(entry);
            return true;
        }

        #endregion
    }
}
