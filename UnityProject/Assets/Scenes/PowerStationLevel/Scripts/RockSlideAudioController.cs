using UnityEngine;
using System.Collections;

public class RockSlideAudioController : MonoBehaviour 
{
	public float MaxVelocity = 0.948f;
	public GameObject WatchFor;
	public AudioSource SlideSource;

	void OnCollisionStay2D(Collision2D other) 
	{
		if (WatchFor == null) { Destroy(this.gameObject); }
		if (other.gameObject.name != WatchFor.name) { return; }
		float velocity = Mathf.Abs(WatchFor.rigidbody2D.velocity.x);
		
		SlideSource.volume = velocity / MaxVelocity;

		if (velocity > 0.01) {
			if (!SlideSource.isPlaying) {
				SlideSource.Play();
			}
		} else {
			SlideSource.Stop();
		}
	}

	void OnCollisionExit2D(Collision2D other) 
	{
		if (other.gameObject.name != WatchFor.name) { return; }

		SlideSource.Stop();
	}
}
