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

        #region Overridden Methods

        public sealed override void Interact()
        {
            OnInteract();
        }

        public sealed override void ConditionsFailed()
        {
            OnConditionsFailed();
        }

        #endregion

        #region Overrideable Methods

        public virtual void OnInteract()
        {
            // Override this in function in subclasses
            MovePlayer();
        }

        public virtual void OnConditionsFailed()
        {
            // Override this in function in subclasses
        }

        #endregion

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
    }
}
