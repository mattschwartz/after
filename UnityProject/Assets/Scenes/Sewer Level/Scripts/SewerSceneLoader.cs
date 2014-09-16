using Assets.Scripts.Scene.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scenes.Sewer_Level.Scripts
{
    public class SewerSceneLoader : SceneLoader
    {
        #region Public Members

        public GameObject Player;

        #endregion

        public override void OnSceneLoaded()
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PlayerIgnores"));
            var sceneData = SceneDataManager.dbGet(Application.loadedLevelName);

            if (sceneData == null || sceneData.Data.Length == 0) {
                return;
            }

            try {
                Player.transform.position = (Vector3)sceneData.Data[0];
            } catch (InvalidCastException) {
                Debug.LogError("Expected player's position but received: " + sceneData.Data[0]);
            }
        }
    }
}
