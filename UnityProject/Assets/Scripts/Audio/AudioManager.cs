using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : MonoBehaviour
	{
		public readonly string AudioDirectoryRoot = "Assets/Sound/";
		public Dictionary<string, AudioSource> AudioSources;

		// Implement this as a button
		public void RefreshSources() 
		{
			DirectoryInfo dInfo = new DirectoryInfo(AudioDirectoryRoot);
			var fileList = dInfo.GetFiles("*.mp3");

			foreach (var fInfo in fileList) {
				Debug.Log("Found match: " + fInfo);
			}
		}

		// Implement this as a button
		public void ClearSources() 
		{

		}
	}
	}
