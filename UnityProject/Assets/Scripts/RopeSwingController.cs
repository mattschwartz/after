using UnityEngine;
using System.Collections;
using Assets.Scripts.Scene.SceneManagement;

public class RopeSwingController : MonoBehaviour {

	public GameObject PlayerObject;
	public float MinLength;
    private float Length;
	public float MaxLength;
	public float FallRate;
    public float TimeToFall;
    //public float Tension;
	private Transform Trans;
    private bool Active;
    private bool Entered;
    private bool Dismount;
    //private bool Falling;
    private float TimeInterval;
    //private float Displace;  //in radians
    public Rigidbody2D Body;
    public Rigidbody2D Anchor;

	// Use this for initialization
	void Start () {
		Active = false;
		Entered = false;
        Dismount = false;
        Length = MinLength;

		Trans = GetComponent<Transform>();

        //give rope some initial sway
        Body.AddForce(new Vector2(20f, 0f));
	}

	void OnTriggerEnter2D ()
	{
		Entered = true;

        Body.angularDrag = 0f;
	}

	void OnTriggerExit2D ()
	{
		Entered = false;
        Dismount = false;

        Body.angularDrag = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Entered && !Active && !Dismount)
		{
			Active = true;
			PlayerObject.SendMessage("Swing", true);

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

            //rotates player model with rope
            PlayerObject.rigidbody2D.transform.rotation = Trans.rotation;

			//applies an initial swinging force to the rope if it's stationary
            Body.AddForce(new Vector2(750f * xSign, 0));

            //suspends player gravity
            PlayerObject.rigidbody2D.gravityScale = 0;

            //eliminates rope drag
            Body.angularDrag = 0f;
		}
		else if (Active && Input.GetKeyDown(KeyCode.Space))
		{
            Dismount = true;
            Active = false;

            //reset player rotation
            PlayerObject.rigidbody2D.transform.rotation = Quaternion.identity;

            //reapplies gravity to player
            PlayerObject.rigidbody2D.gravityScale = 8;

            //apply force to player coming off rope
            float xSign;
            if (Trans.rotation.z > 180f)
                xSign = -1;
            else
                xSign = 1;
            PlayerObject.rigidbody2D.AddForce(new Vector2(1000f * xSign, 500f));

            PlayerObject.SendMessage("Swing", false);

            //rope active status will be changed upon player leaving trigger box
		}
		else if (Active)
		{
            //ensure player gravity stays disabled
            if (PlayerObject.rigidbody2D.gravityScale != 0)
                PlayerObject.rigidbody2D.gravityScale = 0;

            //keep player on rope
            Vector3 hToA = new Vector3(0f, 0f - Length, 0f);
            hToA = Trans.rotation * hToA;
            PlayerObject.rigidbody2D.transform.position = Trans.position + hToA;
            //rotate player with rope
            PlayerObject.rigidbody2D.transform.rotation = Trans.rotation;

            //Allow player to add force to rope
            float hInput = Input.GetAxis("Horizontal");
            Body.AddForce(new Vector2(5f * hInput, 0));
		}
	}
}
