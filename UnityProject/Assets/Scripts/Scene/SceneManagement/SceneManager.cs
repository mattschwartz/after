using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
}
