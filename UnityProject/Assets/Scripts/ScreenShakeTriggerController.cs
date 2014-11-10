using UnityEngine;
using System.Collections;
using After.CameraTransitions;

public class ScreenShakeTriggerController : MonoBehaviour
{
    #region Members

    public Collider2D WatchFor;

    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        if (WatchFor && WatchFor == other) {
            CameraShakerController.Instance.Shake();
        }
    }
}
