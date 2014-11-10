using UnityEngine;
using System.Collections;

public class CoMController : MonoBehaviour 
{
	public Vector2 com;
	public Rigidbody2D rigidBody;

	void Start()
	{
		rigidBody.centerOfMass = com;
	}
}
