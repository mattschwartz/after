using UnityEngine;
using System.Collections;

public class AudioTriggerController : MonoBehaviour 
{
	public bool StopOnExit = false;

	private AudioSource AudioSource;

	void Start()
	{
		AudioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("Playing");
		AudioSource.Play();
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (StopOnExit) {
			AudioSource.Stop();
		}
	}
}
