using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace After.Audio 
{
	public class AudioManager : MonoBehaviour
	{
		public bool Verbose = false;
		public List<string> MaterialTypes = new List<string>();
		public List<AudioClip> AudioSources = new List<AudioClip>();
		public Dictionary<string, List<AudioClip>> MaterialStepSounds = new Dictionary<string, List<AudioClip>>();

		// Implemented as a button in Unity editor
		public void RefreshSources() 
		{
			string soundPath = Application.dataPath + "/Resources/Sound";

			ClearSources();

			var fileList = Directory.GetFiles(soundPath, "*.ogg", SearchOption.AllDirectories);

			foreach (var fName in fileList) {
				var fInfo = new FileInfo(fName);
				
				if (Verbose) {
					Debug.Log("Found: " + Relativize(fInfo));
				}

				string asset = Relativize(fInfo);
				AudioClip clip = Resources.Load<AudioClip>(asset);

				if (clip == null) {
					Debug.LogError("Failed to load asset: " + asset);
				}

				AudioSources.Add(clip);
				AddMaterialStepSound(fInfo.Name, clip);
			}

			foreach (var key in MaterialStepSounds.Keys) {
				foreach (var sound in MaterialStepSounds[key]) {
					Debug.Log(key + " - " + sound);
				}
			}
		}

		// Implemented as a button in Unity editor
		public void ClearSources() 
		{
			AudioSources = new List<AudioClip>();
			MaterialStepSounds = new Dictionary<string, List<AudioClip>>();
		}

		private string Relativize(FileInfo fInfo) 
		{
			int start = fInfo.FullName.IndexOf("Sound");
			int end = fInfo.FullName.IndexOf(".") - start;

			if (start < 0 || end < 0) {
				return fInfo.FullName;
			}

			return fInfo.FullName.Substring(start, end);
		}

		private void AddMaterialStepSound(string clipName, AudioClip clip) 
		{
			foreach (var material in MaterialTypes) {
				if (clipName.Contains(material)) {

					if (!MaterialStepSounds.ContainsKey(material)) {
						MaterialStepSounds[material] = new List<AudioClip>();
					}

					MaterialStepSounds[material].Add(clip);
				}
			}
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
