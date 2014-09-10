using UnityEngine;
using System.Collections;

public class ObjectiveController : MonoBehaviour {

    private bool Entered;

	// Use this for initialization
	void Start () {
        Entered = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Entered && Input.GetKeyDown(KeyCode.E)) {

        }	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Entered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;
    }
}
