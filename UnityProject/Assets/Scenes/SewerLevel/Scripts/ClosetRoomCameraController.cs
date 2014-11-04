using UnityEngine;
using System.Collections;

public class ClosetRoomCameraController : MonoBehaviour
{
    #region Public Members

    public Transform CenterCameraOnTransform;

    private bool PlayerEntered = false;

    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            PlayerEntered = true;
            Camera.main.SendMessage("SetStaticCamera", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            PlayerEntered = false;
            Camera.main.SendMessage("SetStaticCamera", false);
        }
    }

    void Update()
    {
        if (!PlayerEntered) { return; }

        var pos = CenterCameraOnTransform.position;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
    }
}
