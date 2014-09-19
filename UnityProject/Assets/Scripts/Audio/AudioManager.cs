using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : ScriptableObject
	{
		public bool Verbose = false;
		public List<string> MaterialTypes = new List<string>();
		public List<AudioClip> AudioSources = new List<AudioClip>();
		public Dictionary<string, List<AudioClip>> MaterialStepSounds = new Dictionary<string, List<AudioClip>>();

        public static AudioManager Instance;

        private AudioManager()
        {

        }

		public void ClearSources() 
		{
            AudioSources = new List<AudioClip>();
            MaterialStepSounds = new Dictionary<string, List<AudioClip>>();
		}

		public static void PlayClipAtPoint(string clipName, Vector2 position) 
		{
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.PlayOneShot(Instance.AudioSources.First(t => t.name == clipName));

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

        public static void PlayMaterialFootstepAtPoint(string material, Vector2 position)
        {
            if (!Instance.MaterialStepSounds.ContainsKey(material)) {
                Debug.LogWarning("No footsteps for material of type " + material + ".");
                return;
            }

            var footsteps = Instance.MaterialStepSounds[material];
            int index = Random.Range(0, footsteps.Count);

            if (index >= footsteps.Count) {
                Debug.LogWarning("Index was out of range unexpectedly: " + index);
                return;
            }

            var clip = footsteps[index];
            PlayClipAtPoint(clip, position);
        }
	}
}
