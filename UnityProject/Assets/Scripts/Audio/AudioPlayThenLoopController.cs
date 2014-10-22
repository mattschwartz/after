using UnityEngine;
using System.Collections;

namespace After.Audio 
{
	public class AudioPlayThenLoopController : MonoBehaviour 
	{

		public float Delay;
		public AudioClip OneShotClip;
		public AudioClip LoopClip;

		void Start() 
		{
			StartCoroutine(PlayThenLoop());
		}

		private IEnumerator PlayThenLoop()
		{
			AudioManager.PlayClipAtPoint(OneShotClip, transform.position);
			yield return new WaitForSeconds(Delay);
			AudioManager.LoopClipAtPoint(LoopClip, transform.position);
		}
	}	
}

