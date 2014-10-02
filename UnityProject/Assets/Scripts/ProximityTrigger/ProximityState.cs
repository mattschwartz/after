using After.Interactable;
using After.Interactable.Conditions;
using UnityEngine;

namespace After.ProximityTrigger
{
    public class ProximityState : MonoBehaviour
    {
        public StateType To;
        public InteractableConditions Conditions;

        public virtual StateType? OnEnter(Collider2D other)
        {
            if (Conditions == null || Conditions.ConditionsMet()) {
                return To;
            }

            return null;
        }

        public virtual StateType? OnRemain(Collider2D other)
        {
            if (Conditions == null || Conditions.ConditionsMet()) {
                return To;
            }
            
            return null;
        }

        public virtual StateType? OnExit(Collider2D other)
        {
            if (Conditions == null || Conditions.ConditionsMet()) {
                return To;
            } 
            
            return null;
        }
    }
}
