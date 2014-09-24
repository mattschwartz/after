using UnityEngine;
using System.Collections;
using After.Interactable;

public class DeskInteractableController : ItemSpawnerController
{
    #region Public Members

	public GameObject Player;
    public GameObject ClosetRoomDoor;

    #endregion

    public override void OnInteract()
    {
    	PlayOnFailure = null;
    	PlayOnSuccess = null;
    	Player.SendMessage("OpenDesk", transform.position);
        ClosetRoomDoor.SendMessage("MeetConditions");
    }
}
