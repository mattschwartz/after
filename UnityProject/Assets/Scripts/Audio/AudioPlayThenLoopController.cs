using UnityEngine;
using System.Collections;

namespace After.Audio 
{
	public class AudioPlayThenLoopController : MonoBehaviour 
	{
		#region Members

		public float Delay;
		public float OneShotVolume = 1;
		public float LoopVolume = 1;
		public AudioClip OneShotClip;
		public AudioClip LoopClip;

		#endregion

		void Start() 
		{
			StartCoroutine(PlayThenLoop());
		}

		private IEnumerator PlayThenLoop()
		{
			AudioManager.PlayClipAtPoint(OneShotClip, transform.position, OneShotVolume);
			yield return new WaitForSeconds(Delay);
			AudioManager.LoopClipAtPoint(LoopClip, transform.position, LoopVolume);
		}
	}	
}

