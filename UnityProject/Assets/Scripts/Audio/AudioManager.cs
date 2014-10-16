using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityOSC;

namespace After.Audio 
{
	public class AudioManager : ScriptableObject
    {
        private static readonly string ClientId = "SuperCollider";

        void Start() 
        {
            // Initialize OSC
            // Debug.Log("Initializing OSC.");
            // OSCHandler.Instance.Init();
        }

        public static void SendSCMessage<T>(string oscAddress, T val)
        {
            OSCHandler.Instance.SendMessageToClient(ClientId, oscAddress, val);
        }

        void Update()
        {
            OSCHandler.Instance.UpdateLogs();
        }

        public static GameObject CreateAudioObject(AudioClip clip, Vector2 position, float volume = 1.0f)
        {
            GameObject gameObject = new GameObject();
            var source = gameObject.AddComponent<AudioSource>();

            source.volume = volume;
            source.playOnAwake = false;
            source.clip = clip;
            gameObject.transform.position = position;

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
            source.Play();
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
