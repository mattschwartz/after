using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour {

    public float Height;
    public GameObject PlayerObject;
    private bool FinishedClimbing = false;
    private bool Entered = false;
    public BoxCollider2D Top;

    void Start()
    {
        Top.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Entered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;

        if (FinishedClimbing)
        {
            FinishedClimbing = false;
            PlayerObject.SendMessage("Climb", true);
            Top.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Entered && Input.GetKeyDown(KeyCode.E))
        {
            FinishedClimbing = !FinishedClimbing;
            PlayerObject.SendMessage("Climb", false);
            Top.enabled = false;

            // this is very jerky with camera following the player...
            // needs a fix.
            PlayerObject.transform.position = new Vector2(transform.position.x, PlayerObject.transform.position.y);
        }
    }
}
