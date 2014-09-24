using System;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableConditions : MonoBehaviour
    {
        public bool RepeatSuccess = true;
        public string ThoughtsOnFailure;
        public string ThoughtsOnSuccess;

        protected bool TaskCompleted = false;

        public virtual void MeetConditions()
        {
            // Can use this to cause conditions to become true
        }

        // Don't override this method
        public bool ConditionsMet()
        {
            if (TaskCompleted && !RepeatSuccess) {
                return true;
            }

            var result = TestConditionsMet();

            if (result && !String.IsNullOrEmpty(ThoughtsOnSuccess)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnSuccess);
            } else if (!result && !String.IsNullOrEmpty(ThoughtsOnFailure)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnFailure);
            }

            return result;
        }

        public virtual bool TestConditionsMet()
        {
            // Override this method in subclasses
            return true;
        }
    }
}
