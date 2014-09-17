using UnityEngine;
using System.Collections;

public class ClosetRoomCameraController : MonoBehaviour
{
    #region Public Members

    public Transform CenterCameraOnTransform;

    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        Camera.main.SendMessage("SetStaticCamera", true);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var pos = CenterCameraOnTransform.position;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Camera.main.SendMessage("SetStaticCamera", false);
    }
}
