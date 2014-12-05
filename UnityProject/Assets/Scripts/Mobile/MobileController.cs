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
    private float TouchedFor;
    private Vector2 LastMovePosition;
    private Vector2 LastLadderPosition;
    private Rect IconBounds;
    private List<int> PossibleJumpTouches;

    #endregion

    void Start()
    {
        if (Application.platform != RuntimePlatform.Android &&
            Application.platform != RuntimePlatform.IPhonePlayer) {
            Debug.LogWarning("Deleting mobile controller. You shouldn't be building with me!");
            Destroy(gameObject);
        }

        PossibleJumpTouches = new List<int>();
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
        ProcessLadder();
        Unstucker();
    }

    private void DefineBounds()
    {
        float scale = Screen.width / 960f;
        float w = 128 * scale;
        float h = 128 * scale;
        IconBounds = new Rect(Screen.width - w, Screen.height - h, w, h);
    }

    private void Unstucker()
    {
        if (Input.touchCount == 0) {
            PossibleJumpTouches.Clear();
            LastLadderPosition = Vector2.zero;
            LastMovePosition = Vector2.zero;
        }
    }

    private void ProcessJump()
    {
        SceneHandler.SwingDismount = false;

        // A touch has been previously recorded and it has just ended
        if (PossibleJumpTouches.Any(t => Input.GetTouch(t).phase == TouchPhase.Ended)) {
            // Has the touch been held for too long to be considered a jump?
            if (TouchedFor <= JumpThreshold) {
                SceneHandler.SwingDismount = true;
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

        int count = PossibleJumpTouches.Count;

        // Keep track of possible jump touches based on all touches that have begun
        PossibleJumpTouches.AddRange(Input.touches.ToList()
            .Where(t => t.phase == TouchPhase.Began)
            .Select(t => t.fingerId));

        // If we added more touches, reset timer
        if (count < PossibleJumpTouches.Count) {
            TouchedFor = 0;
        }

        // Found no valid touches - time to bail
        if (PossibleJumpTouches.Count == 0) { return; }

        // At least 1 finger is being held down and has not moved.
        TouchedFor += Time.deltaTime;
    }

    private void ProcessMove()
    {
        if (Player.Climbing) { return; }

        // Movement will always be performed by the first registered touch
        if (Input.touchCount == 0 || Input.touches[0].phase == TouchPhase.Ended) {
            Player.Move(0);
            return;
        }

        Touch moveTouch = Input.touches[0];

        if (moveTouch.phase == TouchPhase.Began) {
            LastMovePosition = moveTouch.position;
        }

        Vector2 mouse = moveTouch.position;

        float deltaY = (mouse.y - LastMovePosition.y);
        float deltaX = (mouse.x - LastMovePosition.x);
        float min = (float)Screen.width * 0.01f;

        //if (deltaY > deltaX) { return; }

        // Ignore moves between -min and min
        if (deltaX < -min) {
            deltaX = -1;
        } else if (deltaX > min) {
            deltaX = 1;
        } else {
            deltaX = 0;
        }

        Player.Move(deltaX);
    }

    private void ProcessLadder()
    {
        //Vector2 mouse = moveTouch.position;
        ResetLadderMovement();
        Player.Climb(0);

        if (Input.GetMouseButtonUp(0)) { return; }

        if (Input.GetMouseButtonDown(0)) {
            LastLadderPosition = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0)) { return; }

        Vector2 mouse = Input.mousePosition;

        float deltaY = (mouse.y - LastLadderPosition.y);
        float deltaX = (mouse.x - LastLadderPosition.x);

        if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX)) {
            if (deltaY < 0) {
                SceneHandler.LadderDown = true;
                Player.Climb(-1);
            } else if (deltaY > 0) {
                SceneHandler.LadderUp = true;
                Player.Climb(1);
            }
        } else {
            if (deltaX < 0) {
                SceneHandler.LadderLeft = true;
            } else if (deltaX > 0) {
                SceneHandler.LadderRight = true;
            }
        }
    }

    private void ResetLadderMovement()
    {
        SceneHandler.LadderUp = false;
        SceneHandler.LadderDown = false;
        SceneHandler.LadderLeft = false;
        SceneHandler.LadderRight = false;
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
