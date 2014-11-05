using System.Collections;
using UnityEngine;

namespace After.Audio
{
	public class PersistentAudioClip : MonoBehaviour
	{
		#region Members
		
		public float PostLoadFadeDuration = 0;
		public AudioSource Source;

		private bool SceneUnloaded = false;
		private float DurationTracker;

		#endregion

		// TODO: Ensure this function does not get called during scene 
		// transition.
		void Start()
        {
            DontDestroyOnLoad(this);
			AudioManager.Instance.AddPersistentAudioClip(this);
		}

		void OnLevelWasLoaded(int level)
		{
			SceneUnloaded = true;
            DurationTracker = 0;
		}

		void Update()
		{
			if (!SceneUnloaded) { return; }

			float f = 1 - (DurationTracker / PostLoadFadeDuration);
			Source.volume = Mathf.Lerp(0, 1, f);
			DurationTracker += Time.deltaTime;

			if (DurationTracker >= PostLoadFadeDuration) {
				Destroy(this.gameObject);
			}
		}
	}
}
