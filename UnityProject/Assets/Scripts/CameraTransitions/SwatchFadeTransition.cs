using System.Collections;
using UnityEngine;

namespace After.CameraTransitions
{
	public class SwatchFadeTransition : ScriptableObject
	{
		public GUITexture SwatchTexture;
		public static SwatchFadeTransition Instance;

		private bool Fading = false;
		private float t;
		private float Duration;
		private Color StartColor;
		private Color EndColor;

		private SwatchFadeTransition()
		{
		}

		void Start()
		{
			Instance = SwatchFadeTransition.CreateInstance<SwatchFadeTransition>();
			Instance.SwatchTexture = SwatchTexture;
	        Instance.SwatchTexture.transform.position = new Vector3(0, 0, 0);
	        Instance.SwatchTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
            Instance.SwatchTexture.enabled = false;
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.I)) {
				Instance.Fade(Color.white, Color.clear, 1.85f);
			}
			if (!Instance.Fading) { return; }

			float x = Instance.t / Instance.Duration;
			Instance.SwatchTexture.color = Color.Lerp(Instance.StartColor, Instance.EndColor, x);

			Instance.t += Time.deltaTime;

			if (Instance.t >= Instance.Duration) {
				Instance.Fading = false;
				Instance.SwatchTexture.enabled = false;
			}
		}

		public void Fade(Color start, Color end, float duration = 1)
		{
			Fading = true;
			SwatchTexture.enabled = true;
			SwatchTexture.color = start;
			StartColor = start;
			EndColor = end;
			Duration = duration;

			t = 0;
		}
	}
}
