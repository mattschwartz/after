using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace After.Audio 
{
	public class AudioManager : ScriptableObject
    {
        private List<PersistentAudioClip> PersistentAudioClips = new List<PersistentAudioClip>();

        public static AudioManager Instance;

        private AudioManager()
        {
        }

        void Start()
        {
            if (AudioManager.Instance == null) {
                AudioManager.Instance = AudioManager.CreateInstance<AudioManager>();
            } else {
                DontDestroyOnLoad(AudioManager.Instance);
            }

            foreach (var pac in AudioManager.Instance.PersistentAudioClips) {
                DontDestroyOnLoad(pac);
            }
        }

        /// <summary>
        /// Adds a PersistentAudioClip that will not be destroyed when the 
        /// scene unloads.
        /// <see cref="After.Audio.PersistentAudioClip" />
        /// </summary>
        public void AddPersistentAudioClip(PersistentAudioClip pac)
        {
            PersistentAudioClips.Add(pac);
        }

        /// <summary>
        /// Creates, plays and adds a PersistentAudioClip that will not be 
        /// destroyed when the scene is unloaded.
        /// <see cref="After.Audio.PersistentAudioClip" />
        /// </summary>
        public void PlayPersistentAudioClip(
            AudioClip clip, 
            Vector2 position, 
            bool loop = false, 
            float fadeDuration = 0, 
            float volume = 1.0f)
        {
            var source = new AudioSource();
            source.clip = clip;
            source.volume = volume;
            source.loop = loop;
            source.playOnAwake = true;

            var pac = new PersistentAudioClip();
            pac.Source = source;
            pac.PostLoadFadeDuration = fadeDuration;

            PersistentAudioClips.Add(pac);
        }

        public static GameObject CreateAudioObject(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            source.volume = volume;
            source.playOnAwake = false;
            source.clip = clip;
            gameObject.transform.position = position;
            gameObject.name = clip.name;

            return gameObject;
        }

        public static void LoopClipAtPoint(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            source.loop = true;
            source.volume = volume;
            source.playOnAwake = true;
            source.clip = clip;
            gameObject.transform.position = position;
            gameObject.name = clip.name;
            source.Play();
        }

        public static void PlayClipAtPoint(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            if (clip == null) { return; }

            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            gameObject.name = clip.name;
            source.PlayOneShot(clip, volume);

            Destroy(gameObject, clip.length);
        }

        public static void PlayClipAtPoint(
            AudioClip clip, 
            float pitch, 
            Vector2 position, 
            float volume = 1.0f)
        {
            if (clip == null) { return; }

            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            gameObject.transform.position = position;
            gameObject.name = clip.name;
            source.pitch = pitch;
            source.PlayOneShot(clip, volume);

            Destroy(gameObject, clip.length);
        }

        public static void PlayMaterialFootstepAtPoint(
            List<AudioClip> stepSounds, 
            Vector2 position, 
            float volume = 1.0f)
        {
            int index = Random.Range(0, stepSounds.Count);

            if (index < 0 || index >= stepSounds.Count 
                || stepSounds[index] == null) {
                return;
            }

            PlayClipAtPoint(stepSounds[index], position, volume);
        }

        public static void PlayMaterialFootstepAtPoint(
            List<AudioClip> stepSounds, 
            float pitch, 
            Vector2 position, 
            float volume = 1.0f)
        {
            int index = Random.Range(0, stepSounds.Count);

            if (index < 0 || index >= stepSounds.Count 
                || stepSounds[index] == null) {
                return;
            }

            PlayClipAtPoint(stepSounds[index], pitch, position, volume);
        }

        // Must call using StartCoroutine
        public static IEnumerator FadeMusic(AudioSource audioSource)
        {
            while (audioSource.volume > .1F) {
                audioSource.volume = Mathf.Lerp(audioSource.volume, 0, Time.deltaTime);
                yield return 0;
            }
            audioSource.volume = 0;
        }
	}
}
