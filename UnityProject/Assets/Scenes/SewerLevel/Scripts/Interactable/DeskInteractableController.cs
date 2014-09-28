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
        base.OnInteract();

    	PlayWhenFailure = null;
    	PlayWhenSuccess = null;
    	Player.SendMessage("OpenDesk", transform.position);
        ClosetRoomDoor.SendMessage("MeetConditions");
    }
}
