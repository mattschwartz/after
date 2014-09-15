using UnityEngine;
using System.Collections;

public class MechanicRoomDoorController : InteractableController
{
    public SceneLoaderController SceneLoader;

    public override void Interact()
    {
        SceneLoader.SaveScene();
        Application.LoadLevel("Mechanics Room");
    }
}
