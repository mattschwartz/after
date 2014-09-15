using UnityEngine;

namespace Assets.Scripts
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
