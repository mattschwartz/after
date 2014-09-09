using UnityEngine;
using System.Collections;

public class ButtonDisplayController : MonoBehaviour {

    public float Height;
    public GameObject PlayerObject;
    public GameObject ButtonObject;
    private bool FinishedClimbing = false;
    private bool Entered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Entered = true;

        Vector3 buttonPosition = ButtonObject.transform.position;
        buttonPosition.x = transform.position.x;
        buttonPosition.y = transform.position.y + Height;

        ButtonObject.transform.position = buttonPosition;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;
        
        Vector3 buttonPosition = ButtonObject.transform.position;
        buttonPosition.x = -5000;
        buttonPosition.y = -5000;

        ButtonObject.transform.position = buttonPosition;

        if (FinishedClimbing) {
            FinishedClimbing = false;
            PlayerObject.SendMessage("Climb", true);
        }
    }

	// Update is called once per frame
    void Update()
    {
        if (Entered && Input.GetKeyDown(KeyCode.E)) {
            FinishedClimbing = !FinishedClimbing;
            PlayerObject.SendMessage("Climb", false);

            // this is very jerky with camera following the player...
            // needs a fix.
            PlayerObject.transform.position = new Vector2(transform.position.x, PlayerObject.transform.position.y);
        }
	}
}
