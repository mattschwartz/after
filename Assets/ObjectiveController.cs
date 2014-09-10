using UnityEngine;
using System.Collections;

public class ObjectiveController : MonoBehaviour {

    public GameObject ObjectiveMarker;
    public GameObject BendBarsObject;

    private bool Entered;
    private Animator Animator;
    private ParticleSystem ParticleSystem;

	// Use this for initialization
	void Start () {
        Entered = false;
        Animator = GetComponent<Animator>();
        ParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Entered && Input.GetKeyDown(KeyCode.E)) {
            Animator.SetTrigger("FreeSoul");
            ObjectiveMarker.SendMessage("CompleteObjective");
            BendBarsObject.SendMessage("BendBars");

            ParticleSystem.Stop();
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
