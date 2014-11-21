using UnityEngine;
using After.Entities;

namespace After.Scene.SceneManagement 
{
    public class SceneHandler : MonoBehaviour
    {
        public static bool OnInteractable;
        public static bool OnGrabbable;
        public static string PlayerItemHeld;
        public static PlayerController Player;
        public static MonoBehaviour GUILock;

        void Start()
        {
            GUILock = null;
            
            if (Player == null) {
                var go = GameObject.Find("Player");
                Player = go.GetComponent<PlayerController>();
                OnInteractable = false;
                OnGrabbable = false;
            }
        }
    }
}
