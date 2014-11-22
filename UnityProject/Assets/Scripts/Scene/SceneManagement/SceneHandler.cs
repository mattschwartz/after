using UnityEngine;
using After.Entities;

namespace After.Scene.SceneManagement
{
    public class SceneHandler : MonoBehaviour
    {
        #region Members

        public static bool OnMobile;
        public static bool LadderUp;
        public static bool LadderDown;
        public static bool LadderLeft;
        public static bool LadderRight;
        public static bool SwingDismount;
        public static bool OnInteractable;
        public static bool OnGrabbable;
        public static string PlayerItemHeld;
        public static PlayerController Player;
        public static MonoBehaviour GUILock;

        #endregion

        void Start()
        {
            GUILock = null;

            if (Player == null) {
                var go = GameObject.Find("Player");
                Player = go.GetComponent<PlayerController>();
            }
            OnInteractable = false;
            OnGrabbable = false;
            OnMobile = Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer;
        }

        void Update()
        {
            if (!OnMobile) {
                LadderUp = Input.GetKeyDown(KeyCode.W);
                LadderDown = Input.GetKeyDown(KeyCode.S);
                LadderLeft = Input.GetKeyDown(KeyCode.A);
                LadderRight = Input.GetKeyDown(KeyCode.D);
                SwingDismount = Input.GetKeyDown(KeyCode.Space);
            }
        }
    }
}
