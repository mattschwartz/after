using UnityEngine;
using System.Collections;

public class FreedSoulController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        renderer.enabled = false;
	}

    public void CompleteObjective()
    {
        renderer.enabled = true;
    }
}
