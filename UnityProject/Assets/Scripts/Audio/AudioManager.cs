using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace After.Audio 
{
	public class AudioManager : MonoBehaviour
	{
		private readonly string SoundPath = Application.dataPath + "/Resources/Sound";
		public bool Verbose = false;
		public List<AudioClip> AudioSources = new List<AudioClip>();

		public void RefreshSources() 
		{
			ClearSources();

			var fileList = Directory.GetFiles(SoundPath, "*.ogg", SearchOption.AllDirectories);

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
			}
		}

		public void ClearSources() 
		{
			AudioSources = new List<AudioClip>();
		}

		public static void PlayClipAtPoint(string clipName, Vector2 position) 
		{
			// create an empty game object
			// attach clip to it
			// positio it
			// play it
			// destroy it
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
	}
}
