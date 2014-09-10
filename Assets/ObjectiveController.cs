using UnityEngine;
using System.Collections;

public class ObjectiveController : MonoBehaviour {

    private bool Entered;
    private Animator Animator;

	// Use this for initialization
	void Start () {
        Entered = false;
        Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Entered && Input.GetKeyDown(KeyCode.E)) {
            Animator.SetTrigger("FreeSoul");
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
