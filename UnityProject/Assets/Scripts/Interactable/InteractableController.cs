using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Audio;

namespace After.Interactable
{
    public class InteractableController : MonoBehaviour
    {
        #region Public Members

        public KeyCode InteractButton = KeyCode.E;
        public InteractableConditions Conditions;
        public AudioClip PlayWhenFailure;
        public AudioClip PlayFirstSuccess;
        public AudioClip PlayWhenSuccess;

        #endregion

        #region Private Members

        private bool Entered = false;

        #endregion

        #region Interact

        //protected void Update()
        //{
        //    // Player is within reach of the interactable and invokes InteractButton
        //    if (Entered && Input.GetKeyDown(InteractButton)) {
        //    }
        //}

        public void Interact()
        {
            // Conditions met?
            if (Conditions == null || Conditions.ConditionsMet()) {
                PlaySuccess();
                OnInteract();
            } else {
                PlayFailure();
                ConditionsFailed();
            }
        }

        #endregion

        #region Sound Clips

        public virtual void PlaySuccess() 
        {
            // Clip plays only once
            if (PlayFirstSuccess) {
                AudioManager.PlayClipAtPoint(PlayFirstSuccess, transform.position);
                PlayFirstSuccess = null;
            }

            if (PlayWhenSuccess) {
                AudioManager.PlayClipAtPoint(PlayWhenSuccess, transform.position);
            }
        }

        public virtual void PlayFailure() 
        {
            if (PlayWhenFailure) {
                AudioManager.PlayClipAtPoint(PlayWhenFailure, transform.position);
            }
        }

        #endregion

        #region Triggers

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!InLayerMask(other)) {
                return;
            }

            Entered = true;
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (!InLayerMask(other)) {
                return;
            }

            Entered = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Entered = false;
        }

        bool InLayerMask(Collider2D other)
        {
            return other.gameObject.layer == LayerMask.NameToLayer("Player");
        }

        #endregion

        public void MeetConditions()
        {
            if (Conditions != null) {
                Conditions.MeetConditions();
            }
        }

        public virtual void OnInteract()
        {
            // Override this function in subclasses
        }

        public virtual void ConditionsFailed()
        {
            // Override this function in subclasses
        }
    }
}
