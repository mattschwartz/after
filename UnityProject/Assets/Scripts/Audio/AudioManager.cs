using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : MonoBehaviour
	{
		public bool Verbose = false;
		public List<string> MaterialTypes = new List<string>();
		public List<AudioClip> AudioSources = new List<AudioClip>();
		public Dictionary<string, List<AudioClip>> MaterialStepSounds = new Dictionary<string, List<AudioClip>>();

		public void ClearSources() 
		{
			AudioSources = new List<AudioClip>();
			MaterialStepSounds = new Dictionary<string, List<AudioClip>>();
		}

		public static void PlayClipAtPoint(string clipName, Vector2 position) 
		{
			// create an empty game object
			// attach clip to it
			// positio it
			// play it
			// destroy it
		}
	}
}
