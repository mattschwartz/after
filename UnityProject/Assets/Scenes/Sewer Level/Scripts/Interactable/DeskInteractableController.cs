using UnityEngine;
using System.Collections;
using After.Interactable;

public class DeskInteractableController : ItemSpawnerController
{
    #region Public Members

    public GameObject ClosetRoomDoor;

    #endregion

    public override void OnInteract()
    {
        ClosetRoomDoor.SendMessage("MeetConditions");
    }
}
