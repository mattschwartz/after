using UnityEngine;
using System.Collections;

public class StairColliderController : MonoBehaviour {

    public BoxCollider2D Steps;
    public BoxCollider2D Top;

	// Use this for initialization
	void Start () {
        Steps.enabled = false;
        Top.enabled = true;
	}

    void OnTriggerExit2D(Collider2D other)
    {
        Steps.enabled = false;
        Top.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
