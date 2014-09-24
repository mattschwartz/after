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
        public AudioClip PlayOnFailure;
        public AudioClip PlayOnSuccess;

        #endregion

        #region Private Members

        private bool Entered = false;

        #endregion

        #region Update

        protected void Update()
        {
            if (Entered && Input.GetKeyDown(InteractButton)) {
                if (Conditions == null || Conditions.ConditionsMet()) {
                    PlaySuccess();
                    Interact();
                } else {
                    PlayFailure();
                    ConditionsFailed();
                }
            }
        }

        #endregion

        #region Sound Clips

        public virtual void PlaySuccess() 
        {
            if (!PlayOnSuccess) { return; }
     
            AudioManager.PlayClipAtPoint(PlayOnSuccess, transform.position);
        }

        public virtual void PlayFailure() 
        {
            if (!PlayOnFailure) { return; }
            
            AudioManager.PlayClipAtPoint(PlayOnFailure, transform.position);
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

        public virtual void Interact()
        {
            // Override this function in subclasses
        }

        public virtual void ConditionsFailed()
        {
            // Override this function in subclasses
        }
    }
}
