using UnityEngine;
using System.Collections;
using After.Interactable;

public class DeskInteractableController : InteractableController
{
    #region Public Members

    public GameObject ClosetRoomDoor;

    #endregion

    public override void Interact()
    {
        ClosetRoomDoor.SendMessage("MeetConditions");
    }
}
