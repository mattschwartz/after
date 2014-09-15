using UnityEngine;
using System.Collections.Generic;

public class StepSoundController : MonoBehaviour {

	#region Public Members

	public bool StopBeforePlay = true;

	#endregion

	#region Private Members

	private List<AudioSource> StepSounds; // random sound plays when player makes footstep

	#endregion

	void Start () {
		StepSounds = new List<AudioSource>(GetComponents<AudioSource>());
	}

	// Play random sound from list of sounds provided, called from
	// outside this file
	public void Step() 
	{
		if (StopBeforePlay) {
			StopAllSounds();
		}
		GetRandomSound().Play();
	}

	// Stop all currently playing sounds
	private void StopAllSounds()
	{
		foreach (var source in StepSounds) {
			source.Stop();
		}
	}

	private AudioSource GetRandomSound() 
	{
		int index = Random.Range(0, StepSounds.Count);

		return StepSounds[index];
	}
}
