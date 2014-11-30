using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class DestroyPromptTransition : ProximityTransition 
    {
        public GameObject ToDestroy;

        public override void Read(StateType fromState, StateType toState)
        {
            Destroy(ToDestroy);
        }
    }
}
