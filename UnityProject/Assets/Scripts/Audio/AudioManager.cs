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


			// string[] directories = Directory.GetDirectories(AudioDirectoryRoot);

			// foreach (string dir in directories) {
			// 	Debug.Log("Searching directory named: " + dir);

			// 	Directory.GetFiles(dir)
			// 		.Where(t => t.Extension == ".mp3")
			// 		.ForEach(t =>
			// 			AssetDatabase.ImportAsset(t, ImportAssetOptions.Default),
			// 				Debug.Log("Found asset: " + (t as fInfo).FullName)
			// 			);
			// }
		}

		// Implement this as a button
		public void ClearSources() 
		{

		}
	}
}
