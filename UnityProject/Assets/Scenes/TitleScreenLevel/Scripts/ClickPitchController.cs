using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using After.Audio;

public class ClickPitchController : MonoBehaviour 
{
	#region Members

	public float Volume = 1;
	public AudioClip ClickClip;
	private List<float> Notes;

	#endregion

	void Start() 
	{
		Notes = new List<float>() {
			0.05946309435905f,
			0.12246204830885f,
			0.1892071150019f,
			0.2599210498937f,
			0.3348398541685f,
			0.4142135623711f,

			-0.05946309435905f,
			-0.12246204830885f,
			-0.1892071150019f,
			-0.2599210498937f,
			-0.3348398541685f,
			-0.4142135623711f
		};
	}
	
	void Update() 
	{
		float pitch = 1 + (Notes[Random.Range(0, Notes.Count - 1)]);
		AudioManager.PlayClipAtPoint(ClickClip, pitch, transform.position, Volume);
	}
}
