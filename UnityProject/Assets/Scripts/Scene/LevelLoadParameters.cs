using UnityEngine;

namespace After.Scene
{
    public class LevelLoadParameters
    {
        public string SendingSceneName; // The name of the scene that is loading the next scnene
        public Vector2 PlayerPosition;
        public GameObject Player;

        public LevelLoadParameters()
        {
            SendingSceneName = Application.loadedLevelName;
        }
    }
}
