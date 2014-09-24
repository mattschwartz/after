using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Scene.SceneManagement
{
    public class SceneManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;
        public SceneUnloader SceneUnloader;

        void Awake()
        {
            if (SceneLoader != null) {
                SceneLoader.OnSceneLoaded();
            }
        }

        public void UnloadScene()
        {
            if (SceneUnloader != null) {
                SceneUnloader.OnSceneUnloaded();
            }
        }
    }

    public static class PlayerObserver
    {
        private static Vector2 Velocity;

        public static void SetPlayerVel(Vector2 vel)
        {
            Velocity = vel;
        }

        public static Vector2 GetPlayerVel()
        {
            return Velocity;
        }
    }
}