using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace After.Audio 
{
	public class AudioManager : ScriptableObject
    {
        public static void LoopClipAtPoint(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            
        }

        public static void PlayClipAtPoint(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            if (clip == null) { return; }

            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.PlayOneShot(clip, volume);

            Destroy(gameObject, clip.length);
        }

        public static void PlayClipAtPoint(AudioClip clip, float pitch, Vector2 position, float volume = 1.0f)
        {
            if (clip == null) { return; }

            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            source.pitch = pitch;
            source.PlayOneShot(clip, volume);

            Destroy(gameObject, clip.length);
        }

        public static void PlayMaterialFootstepAtPoint(List<AudioClip> stepSounds, Vector2 position, float volume = 1.0f)
        {
            int index = Random.Range(0, stepSounds.Count);

            if (index < 0 || index >= stepSounds.Count 
                || stepSounds[index] == null) {
                return;
            }

            PlayClipAtPoint(stepSounds[index], position, volume);
        }

        public static void PlayMaterialFootstepAtPoint(List<AudioClip> stepSounds, float pitch, Vector2 position, float volume = 1.0f)
        {
            int index = Random.Range(0, stepSounds.Count);

            if (index < 0 || index >= stepSounds.Count 
                || stepSounds[index] == null) {
                return;
            }

            PlayClipAtPoint(stepSounds[index], pitch, position, volume);
        }
	}
}
