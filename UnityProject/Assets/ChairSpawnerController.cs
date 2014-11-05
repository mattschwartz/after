using UnityEngine;
using System.Collections;

public class ChairSpawnerController : MonoBehaviour 
{
	public float SpawnTime;
	public GameObject SpawnMe;

	private float Ticker;

	void Update() 
	{
		Ticker += Time.deltaTime;

		if (Ticker >= SpawnTime) {
			SpawnChair();
			Ticker = 0;
		}
	}	

	private void SpawnChair()
	{
		GameObject copy = (GameObject)Instantiate(SpawnMe, transform.position, Quaternion.identity);
		float xForce = Random.Range(-1000, 1000);
		float yForce = Random.Range(-1000, 1000);
		copy.rigidbody2D.AddForce(new Vector2(xForce, yForce));
	}
}
