using UnityEngine;
using System.Collections;
using After.Audio;

public class FallingRockSoundController : MonoBehaviour 
{
	public float Volume = 1;
	public GameObject WatchForFallingRock;
	public AudioClip RockLandClip;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == WatchForFallingRock.name) {
			AudioManager.PlayClipAtPoint(RockLandClip, transform.position, Volume);
			DestroyAfter(gameObject, RockLandClip.length);
		}
	}

	private IEnumerator DestroyAfter(GameObject gameObject, float after)
	{
		yield return new WaitForSeconds(after);
		Destroy(gameObject);
	}
}
