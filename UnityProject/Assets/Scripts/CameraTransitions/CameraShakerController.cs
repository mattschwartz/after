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
		void OnGUI (){
      if (GUI.Button (new Rect (20,40,80,20), "Shake")){
         Shake ();
      }
   }

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
				// Camera.main.transform.position = originPosition;
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