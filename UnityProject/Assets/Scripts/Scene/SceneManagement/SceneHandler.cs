using UnityEngine;
using After.Entities;

namespace After.Scene.SceneManagement 
{
    public class SceneHandler : MonoBehaviour
    {
        public static string PlayerItemHeld;
        public static PlayerController Player;
        public static bool GUILock = false;

        void Start()
        {
            if (Player == null) {
                var go = GameObject.Find("Player");
                Player = go.GetComponent<PlayerController>();
            }
        }
    }
}
