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

        public static CameraShakerController Instance { get; private set; }

		#endregion

		// Uncomment for testing shaker via a button.
		// void OnGUI()
		// {
		// 	if (GUI.Button (new Rect (20,40,80,20), "Shake")) {
		// 		Shake ();
		// 	}
		// }

   		void Start()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(this);
            } else if (this != Instance) {
                Debug.Log("Another instance of " + this.GetType().Name
                    + " exists (" + Instance + ") and is not this! "
                    + "( " + this + ") Destroying this.");
                Destroy(this.gameObject);
            }

            Instance.Shaking = false;
   		}

		void Update ()
		{
			if (!Shaking) { return; }

			if (IntensityTracker > 0) {
				Camera.main.transform.position += 
					Random.insideUnitSphere * IntensityTracker;

				IntensityTracker -= Decay;
			} else {
				Shaking = false;
			}
		}

		public void Shake()
		{
			Shaking = true;
			IntensityTracker = Intensity;
		}
	}
}
