using System;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableConditions : MonoBehaviour
    {
        public string ThoughtsOnFailure;
        public string ThoughtsOnSuccess;

        public virtual void MeetConditions()
        {
            
        }

        public bool ConditionsMet()
        {
            var result = OnConditionsMet();

            if (result && !String.IsNullOrEmpty(ThoughtsOnSuccess)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnSuccess);
            } else if (!result && !String.IsNullOrEmpty(ThoughtsOnFailure)) {
                GameObject.Find("Player Thoughts").SendMessage("SetThought", ThoughtsOnFailure);
            }

            return result;
        }

        public virtual bool OnConditionsMet()
        {
            return true;
        }
    }
}
