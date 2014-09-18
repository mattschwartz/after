using UnityEngine;
using System.Collections;
using Assets.Scripts.Scene.SceneManagement;

public class RopeSwingController : MonoBehaviour {

	public GameObject PlayerObject;
	public float Length;
	public float MaxRotation;
	private Transform Trans;
    private bool Active;
    private bool Entered;

	// Use this for initialization
	void Start () {
		Active = false;

		Trans = GetComponent<Transform>();
	}

	void OnTriggerEnter2D ()
	{
		Entered = true;
	}

	void OnTriggerExit2D ()
	{
		Entered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Entered && !Active)
		{
			Active = true;
		}
		else if (Entered && Active && Input.GetKeyDown(KeyCode.Space))
		{
			Active = false;
		}
		else if (Entered && Active)
		{
			//Physics shit goes here
		}
	}
}
