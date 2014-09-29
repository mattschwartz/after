using UnityEngine;
using System.Collections;
using Assets.Scripts.Scene.SceneManagement;

public class RopeSwingController : MonoBehaviour {

	public GameObject PlayerObject;
	public float Length;
    //public float Tension;
	private Transform Trans;
    private bool Active;
    private bool Entered;
    //private float Displace;  //in radians
    public Rigidbody2D Handle;
    public Rigidbody2D Anchor;

	// Use this for initialization
	void Start () {
		Active = false;
		//Displace = 0f;
		Entered = false;

		Trans = GetComponent<Transform>();
		Handle = GetComponent<Rigidbody2D>();

	}

	void OnTriggerEnter2D ()
	{
		Entered = true;
	}

	void OnTriggerExit2D ()
	{
		Entered = false;
	}

	void FixedUpdate ()
	{
		if (Active)
		{
			/* if (Length < Vector2.Distance(PlayerObject.rigidbody2D.transform.position, Trans.position))
			{
				//coming off the rope, pull player back
				Vector2 norm = Anchor.transform.position - PlayerObject.rigidbody2D.transform.position;
				norm.Normalize();
				PlayerObject.rigidbody2D.transform.position = norm * Length;
			} */
			//PlayerObject.rigidbody2D.transform.position = new Vector3(Handle.transform.position.x, Handle.transform.position.y, Handle.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Entered && !Active)
		{
			Active = true;
			//PlayerObject.SendMessage("Swing");

			//determines which way the player is headed
			float xSign;
			if (PlayerObserver.GetPlayerVel().x != 0f)
			{
				xSign = PlayerObserver.GetPlayerVel().x / Mathf.Abs(PlayerObserver.GetPlayerVel().x);
			}
			else
			{
				//we don't want to divide by zero
				xSign = 1f;
			}

			//snaps player to rope
            Vector3 hToA = new Vector3(0f, 0f - Length, 0f);
            hToA = Trans.rotation * hToA;
            PlayerObject.rigidbody2D.transform.position = Trans.position + hToA;

			//applies an initial swinging force to the rope
			Handle.AddForce(new Vector2(750f * xSign, 0));
		}
		else if (Active && Input.GetKeyDown(KeyCode.Space))
		{
			Active = false;
		}
		//Physics stuff will be found in FixedUpdate()
		else if (Active)
		{
            Vector3 hToA = new Vector3(0f, 0f - Length, 0f);
            hToA = Trans.rotation * hToA;
            PlayerObject.rigidbody2D.transform.position = Trans.position + hToA;
		}
	}
}
