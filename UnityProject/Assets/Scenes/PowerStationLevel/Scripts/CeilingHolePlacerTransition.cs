using UnityEngine;
using System.Collections;
using Assets.Scripts.Utility;
using After.ProximityTrigger.ProximityTransitions;
using After.Interactable;

public class CeilingHolePlacerTransition : ProximityTransition
{
    #region Members

    public SpriteRenderer CeilingHole;

    #endregion

    void Start()
    {
        CeilingHole.enabled = false;
    }

    public override void Read(StateType fromState, StateType toState)
    {
        CeilingHole.enabled = true;
    }
}
