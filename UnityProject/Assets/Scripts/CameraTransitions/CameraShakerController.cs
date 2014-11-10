using UnityEngine;

namespace After.CameraTransitions
{
	public class CameraShakerController : MonoBehaviour
	{
		#region Members

		public float Decay = 0.002f;
		public float Intensity = 0.15f;

		private bool Shaking;
		private float IntensityTracker;
		private Vector3 originPosition;

		#endregion

   		void Start()
   		{
   			Shaking = false;
   		}

		void Update ()
		{
			if (!Shaking) { return; }

			if (IntensityTracker > 0) {
				Camera.main.transform.position = Camera.main.transform.position + 
					Random.insideUnitSphere * IntensityTracker;

				IntensityTracker -= Decay;
			} else {
				Shaking = false;
			}
		}

		void Shake()
		{
			Shaking = true;
			originPosition = Camera.main.transform.position;
			IntensityTracker = Intensity;
		}
	}
}