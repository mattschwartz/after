using UnityEngine;
using System.Collections;

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
