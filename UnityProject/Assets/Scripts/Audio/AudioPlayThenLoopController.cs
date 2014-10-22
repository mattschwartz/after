using UnityEngine;
using System.Collections;

namespace After.Audio 
{
	public class AudioPlayThenLoopController : MonoBehaviour 
	{

		public AudioClip OneShotClip;
		public AudioClip LoopClip;

		void Start() 
		{
			StartCoroutine(PlayThenLoop());
		}

		private IEnumerator PlayThenLoop()
		{
			AudioManager.PlayClipAtPoint(OneShotClip, transform.position);
			yield return new WaitForSeconds(OneShotClip.length);
			AudioManager.LoopClipAtPoint(LoopClip, transform.position);
		}
	}	
}

