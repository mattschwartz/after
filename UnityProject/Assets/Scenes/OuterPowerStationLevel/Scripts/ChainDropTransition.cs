using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class ChainDropTransition : Transition
{
    public Rigidbody2D Rigidbody;

    public override void Read(StateType fromState, StateType toState)
    {
        Rigidbody.gravityScale = 3;
    }
}
