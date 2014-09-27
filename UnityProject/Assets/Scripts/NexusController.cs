using UnityEngine;
using System.Collections;
using Assets.Scripts.Scene.SceneManagement;
using After.Interactable;

namespace After.Scene.NexusControllers
{
    public class NexusController : InteractableController
    {
        #region Public Members

        public Vector3 ToLocation;
        public GameObject Player;
        public SpriteRenderer NewSpriteBounds;

        #endregion

        #region Overrideable Methods

        public override void OnInteract()
        {
            MovePlayer();
        }

        public override void ConditionsFailed()
        {

        }

        /* 
         * This gets called by default when conditions are met.
         * Otherwise, subclasses will decide when this gets called.
         */
        public void MovePlayer()
        {
            if (NewSpriteBounds != null) {
                Camera.main.SendMessage("SetSpriteBounds", NewSpriteBounds);
            }

            Player.transform.position = ToLocation;
        }

        #endregion
    }
}
