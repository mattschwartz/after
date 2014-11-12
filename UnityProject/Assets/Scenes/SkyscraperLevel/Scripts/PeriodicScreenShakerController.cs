using UnityEngine;
using System.Collections;
using After.CameraTransitions;
using After.Audio;
using System.Collections.Generic;
using System.Linq;

public class PeriodicScreenShakerController : MonoBehaviour 
{
	#region Members

	public float Intensity = 0.15f;
	public float Decay = 0.002f;
	public float RangeMin;
	public float RangeMax;
	public float PitchLow = 1;
	public float PitchHigh = 1;
	public float ClipVolume = 1;
	public ParticleSystem FallingRock;
	public List<AudioClip> RumbleClips;

	private float LastShake;
	private float NextShake;

	#endregion

	void Start()
	{
		FallingRock.renderer.sortingLayerName = "Particles";
	}

	void Update () {
		if (!TimeToShake()) { return; }

		CameraShakerController.Instance.Shake(Intensity, Decay);
		RumbleClips.ForEach(t =>
			AudioManager.PlayClipAtPoint(t, transform.position, ClipVolume, PitchLow, PitchHigh));
		
		FallingRock.Stop();
		FallingRock.Simulate(0);
		FallingRock.Play();
	}

	private bool TimeToShake()
	{
		if (LastShake < NextShake) {
			LastShake += Time.deltaTime;
			return false;
		}

		LastShake = 0;
		NextShake = Random.Range(RangeMin, RangeMax);
		return true;
	}
}
