using System;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableConditions : MonoBehaviour
    {
        public bool RepeatSuccess = true;
        public string ThoughtsOnFailure;
        public string ThoughtsOnSuccess;

        protected bool CompletedTask = false;

        public virtual void MeetConditions()
        {
            
        }

        public bool ConditionsMet()
        {
            if (CompletedTask && !RepeatSuccess) { return true; }

            CompletedTask = OnConditionsMet();

            if (CompletedTask && !String.IsNullOrEmpty(ThoughtsOnSuccess)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnSuccess);
            } else if (!CompletedTask && !String.IsNullOrEmpty(ThoughtsOnFailure)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnFailure);
            }

            return CompletedTask;
        }

        public virtual bool OnConditionsMet()
        {
            return true;
        }
    }
}
