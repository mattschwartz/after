using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;

public class MobileController : MonoBehaviour
{
    #region Members

    public float JumpThreshold = 1;
    public PlayerController Player;
    public GUIStyle InspectStyle;
    public GUIStyle GrabbableStyle;

    private bool TouchDown;
    private float TouchedFor;
    private Vector3 LastMouse;
    private Rect IconBounds;

    #endregion

    void Start()
    {
        TouchDown = false;
        TouchedFor = 0;
    }

    void Update()
    {
        DefineBounds();
        ProcessJump();
        ProcessMove();
    }

    private void DefineBounds()
    {
        var campos = Camera.main.ViewportToScreenPoint(new Vector3(1, 1));
        float w = (float)Screen.width * 0.25f;
        float h = (float)Screen.height * 0.25f;
        IconBounds = new Rect(Screen.width - w, Screen.height - h, w, h);
    }

    private bool ProcessJump()
    {
        if (Input.GetMouseButtonDown(0)) {
            TouchDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            if (TouchedFor > 0 && TouchedFor <= JumpThreshold) {
                Player.Jump();
            }

            TouchedFor = 0;
            TouchDown = false;
            return true;
        }

        if (TouchDown) {
            TouchedFor += Time.deltaTime;
        }

        return false;
    }

    private void ProcessMove()
    {
        if (Input.GetMouseButtonUp(0)) {
            Player.Move(0);
        }

        if (Input.GetMouseButtonDown(0)) {
            LastMouse = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0)) {
            return;
        }

        Vector3 mouse = Input.mousePosition;

        float deltaX = (mouse.x - LastMouse.x) / ((float)Screen.width / 2);
        if (deltaX < 0) {
            deltaX = -1;
        } else if (deltaX > 0) {
            deltaX = 1;
        }

        Player.Move(deltaX);
    }

    void OnGUI()
    {
        if (SceneHandler.GUILock != null) { return; }
        
        if (SceneHandler.OnInteractable) {
            if (GUI.Button(IconBounds, GUIContent.none, InspectStyle)) {
                Player.Interact();
            }
        } else if (SceneHandler.OnGrabbable) {
            if (GUI.Button(IconBounds, GUIContent.none, GrabbableStyle)) {
                Player.Interact();
            }
        }
    }
}
