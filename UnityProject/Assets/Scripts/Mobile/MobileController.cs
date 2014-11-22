using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MobileController : MonoBehaviour
{
    #region Members

    public float JumpThreshold = 1;
    public PlayerController Player;
    public GUIStyle InspectStyle;
    public GUIStyle GrabbableStyle;

    private bool GUIInteraction;
    private bool TouchDown;
    private float TouchedFor;
    private Vector2 LastMouse;
    private Rect IconBounds;
    private List<int> PossibleJumpTouches;

    #endregion

    void Start()
    {
        if (Application.platform != RuntimePlatform.Android &&
            Application.platform != RuntimePlatform.IPhonePlayer) {
            Destroy(gameObject);
        }

        PossibleJumpTouches = new List<int>();
        TouchDown = false;
        TouchedFor = 0;
    }

    void Update()
    {
        DefineBounds();

        if (!GUIInteraction) {
            ProcessJump();
        }

        if (Input.touchCount == 0) { GUIInteraction = false; }

        ProcessMove();
    }

    private void DefineBounds()
    {
        float w = (float)Screen.width * 0.25f;
        float h = (float)Screen.height * 0.25f;
        IconBounds = new Rect(Screen.width - w, Screen.height - h, w, h);
    }

    private void ProcessJump()
    {
        // A touch has been previously recorded and it has just ended
        if (PossibleJumpTouches.Any(t => Input.GetTouch(t).phase == TouchPhase.Ended)) {
            // Has the touch been held for too long to be considered a jump?
            if (TouchedFor <= JumpThreshold) {
                Player.Jump();
            }

            // Reset values
            TouchedFor = 0;
            PossibleJumpTouches.Clear();
            return;
        }
        
        // No new registered touches, carry on.
        if (Input.touchCount == 0) { return; }

        // Remove possible jump touches that have moved
        PossibleJumpTouches.RemoveAll(t => Input.touches.ToList()
            .Where(s => s.phase == TouchPhase.Moved)
            .Select(s => s.fingerId)
            .Any(s => s == t));

        // Keep track of possible jump touches based on all touches that have begun
        PossibleJumpTouches.AddRange(Input.touches.ToList()
            .Where(t => t.phase == TouchPhase.Began)
            .Select(t => t.fingerId));

        // Found no valid touches - time to bail
        if (PossibleJumpTouches.Count == 0) { return; }

        // At least 1 finger is being held down and has not moved.
        TouchedFor += Time.deltaTime;
    }

    private void ProcessMove()
    {
        // Movement will always be performed by the first registered touch
        Touch moveTouch = Input.touches[0];

        if (Input.touchCount == 0 || moveTouch.phase == TouchPhase.Ended) {
            Player.Move(0);
            return;
        }

        if (moveTouch.phase == TouchPhase.Began) {
            LastMouse = moveTouch.position;
        }

        Vector2 mouse = moveTouch.position;

        float deltaX = (mouse.x - LastMouse.x);
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
                GUIInteraction = true;
                Player.Interact();
            }
        } else if (SceneHandler.OnGrabbable) {
            if (GUI.Button(IconBounds, GUIContent.none, GrabbableStyle)) {
                GUIInteraction = true;
                Player.Interact();
            }
        }
    }
}
