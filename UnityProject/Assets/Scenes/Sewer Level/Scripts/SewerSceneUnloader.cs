using Assets.Scripts.Scene.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scenes.Sewer_Level.Scripts
{
    public class SewerSceneUnloader : SceneUnloader
    {
        #region Public Members

        public GameObject Player;

        #endregion

        public override void OnSceneUnloaded()
        {
            var sceneData = new SceneData();
            sceneData.Data = new object[] { Player.transform.position };

            SceneDataManager.dbStore(Application.loadedLevelName, sceneData);
        }
    }
}
