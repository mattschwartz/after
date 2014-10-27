using System.Collections;
using UnityEngine;

namespace After.Audio
{
	public class PersistentAudioClip : MonoBehaviour
	{
		#region Members

		public bool SceneUnloaded = false;
		public float PostLoadFadeDuration = 0;
		public AudioSource Source

		private float DurationTracker;

		#endregion

		// TODO: Ensure this function does not get called during scene 
		// transition.
		void Start()
		{
			AudioManager.AddPersistentAudioClip(this);
		}

		void Update()
		{
			if (!SceneUnloaded) { return; }

			float f = (DurationTracker / PostLoadFadeDuration);
			Source.volume = Mathf.Lerp(0, 1, f);
			DurationTracker -= Time.deltaTime;

			if (DurationTracker <= 0) {
				Destroy(this);
			}
		}
	}
}
