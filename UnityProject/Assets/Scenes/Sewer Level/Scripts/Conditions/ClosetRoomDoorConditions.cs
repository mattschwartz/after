using UnityEngine;
using System.Collections;
using After.Interactable;

public class ClosetRoomDoorConditions : InteractableConditions
{
    #region Private Members

    private bool HasKeycode = false;

    #endregion

    public override void MeetConditions()
    {
        HasKeycode = true;
    }

    public override bool ConditionsMet()
    {
        return HasKeycode;
    }
}
