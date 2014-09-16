using UnityEngine;
using System.Collections;
using Assets.Scripts.Scene.SceneManagement;

namespace After.Scene.NexusControllers
{
    public class NexusController : InteractableController
    {
        #region Public Members

        public Vector3 ToLocation;
        public GameObject Player;
        public SpriteRenderer NewSpriteBounds;

        #endregion

        public override void Interact()
        {
            if (NewSpriteBounds != null) {
                Camera.main.SendMessage("SetSpriteBounds", NewSpriteBounds);
            }
            Player.transform.position = ToLocation;
        }

        // Deprecated
        //#region Public Members

        //public string LevelToLoad;
        //public SceneManager SceneManager;

        //#endregion

        //public override void Interact()
        //{
        //    if (SceneManager != null) {
        //        SceneManager.SceneUnloader.OnSceneUnloaded();
        //    }

        //    Application.LoadLevel(LevelToLoad);
        //}
    }
}
