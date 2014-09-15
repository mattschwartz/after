using UnityEngine;

namespace After
{
    // A scriptable object is an asset that is only meant to store data.
    public class InteractableConditions : ScriptableObject
    {
        public bool ConditionsMet()
        {
            return true;
        }
    }
}
