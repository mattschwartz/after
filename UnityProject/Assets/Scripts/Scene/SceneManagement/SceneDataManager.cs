using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Scene.SceneManagement
{
    public static class SceneDataManager
    {
        public static SceneData UnloadedSceneMessage;
        private static Dictionary<string, SceneData> SceneDatabase = new Dictionary<string, SceneData>();

        public static void dbStore(string levelName, SceneData data)
        {
            SceneDatabase[levelName] = data;
        }

        public static SceneData dbGet(string levelName)
        {
            if (!SceneDatabase.ContainsKey(levelName)) {
                return null;
            }

            return SceneDatabase[levelName];
        }
    }
}
