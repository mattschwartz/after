using UnityEngine;
using System.Collections;

public class ChairController : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other) 
	{
		Debug.Log("Colliding with : " + other.gameObject.name);
		if (other.gameObject.name == "Player") {
			float xForce = Random.Range(-1000, 1000);
			float yForce = Random.Range(-1000, 1000);
			rigidbody2D.AddForce(new Vector2(xForce, yForce));
		}
	}
}
