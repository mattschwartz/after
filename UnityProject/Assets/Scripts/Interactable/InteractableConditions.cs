using UnityEngine;

namespace After.Interactable
{
    public class InteractableConditions : MonoBehaviour
    {
        public virtual void MeetConditions()
        {
            
        }

        public virtual bool ConditionsMet()
        {
            return true;
        }
    }
}
