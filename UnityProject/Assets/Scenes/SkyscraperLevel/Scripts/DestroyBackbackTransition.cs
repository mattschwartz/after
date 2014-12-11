using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using After.Interactable.Transitions;
using After.Interactable;

public class DestroyBackbackTransition : Transition
{
    public List<GameObject> ToDestroy;

    public override void Read(StateType fromState, StateType toState)
    {
        if (ToDestroy == null) { return; }

        ToDestroy.ForEach(t => Destroy(t));
    }
}
