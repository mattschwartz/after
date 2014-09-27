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
            // Can be used to force conditions to be true
        }

        // If true, the controllers will not attempt to check conditions and 
        // will not re-execute failure or success code
        public bool ConditionsSpent()
        {
            return false;
        }

        // Don't override this method
        public bool ConditionsMet()
        {
            if (TaskCompleted) {
                return RepeatSuccess;
            }

            var result = TestConditionsMet();
            SetThoughts(result);

            return result;
        }

        // Override this method in subclasses
        public virtual bool TestConditionsMet()
        {
            return true;
        }

        private void SetThoughts(bool conditionsMet)
        {
            if (conditionsMet && !String.IsNullOrEmpty(ThoughtsOnSuccess)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnSuccess);
            } else if (!conditionsMet && !String.IsNullOrEmpty(ThoughtsOnFailure)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnFailure);
            }
        }
    }
}
