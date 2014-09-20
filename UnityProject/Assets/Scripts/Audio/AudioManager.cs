using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : ScriptableObject
    {
        public static void PlayClipAtPoint(AudioClip clip, Vector2 position)
        {
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.PlayOneShot(clip);

            Destroy(gameObject, clip.length);
        }

        public static void PlayMaterialFootstepAtPoint(List<AudioClip> stepSounds, Vector2 position)
        {
            int index = Random.Range(0, stepSounds.Count);

            if (index < 0 || index >= stepSounds.Count 
                || stepSounds[index] == null) {
                return;
            }

            PlayClipAtPoint(stepSounds[index], position);
        }
	}
}
