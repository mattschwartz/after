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
        public List<GameObject> Items;

        #endregion

        public override void OnSceneUnloaded()
        {
            var data = new List<object>();
            var sceneData = new SceneData();

            data.Add(Player.transform.position);

            foreach (var item in Items) {
                data.Add(item.transform.position);
            }

            sceneData.Data = data.ToArray();

            SceneDataManager.dbStore(Application.loadedLevelName, sceneData);
        }
    }
}
