using System;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableConditions : MonoBehaviour
    {
        public string FailureMessage;

        public virtual void MeetConditions()
        {
            
        }

        public bool ConditionsMet()
        {
            var result = OnConditionsMet();

            if (!result && !String.IsNullOrEmpty(FailureMessage)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", FailureMessage);
            }

            return result;
        }

        public virtual bool OnConditionsMet()
        {
            return true;
        }
    }
}
