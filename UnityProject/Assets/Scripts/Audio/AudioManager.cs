using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : MonoBehaviour
	{
		public static bool Verbose = false;
		public static List<string> MaterialTypes = new List<string>();
		public static List<AudioClip> AudioSources = new List<AudioClip>();
		public static Dictionary<string, List<AudioClip>> MaterialStepSounds = new Dictionary<string, List<AudioClip>>();

		public static void ClearSources() 
		{
			AudioSources = new List<AudioClip>();
			MaterialStepSounds = new Dictionary<string, List<AudioClip>>();
		}

		public static void PlayClipAtPoint(string clipName, Vector2 position) 
		{
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.PlayOneShot(AudioSources.First(t => t.name == clipName));

            Destroy(gameObject, source.clip.length);
		}

        public static void PlayClipAtPoint(AudioClip clip, Vector2 position)
        {
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.PlayOneShot(clip);

            Destroy(gameObject, clip.length);
        }
	}
}
