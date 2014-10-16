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
			// var tex = new Texture2D(Screen.height, Screen.width, TextureFormat.ARGB32, false);

			// for (int w = 0; w < tex.width; ++w) {
			// 	for (int h = 0; h < tex.height; ++h) {
			// 		tex.SetPixel(w, h, Color.black);
			// 	}
			// }

			Instance = SwatchFadeTransition.CreateInstance<SwatchFadeTransition>();
			Instance.SwatchTexture = SwatchTexture;
			// tex.Apply();
	        Instance.SwatchTexture.transform.position = new Vector3(0, 0, 0);
	        Instance.SwatchTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
			// Instance.SwatchTexture.texture = tex;
		}

		public void SetDuration(float seconds) 
		{
			Duration = seconds;
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.I)) {
				Instance.Fade(Color.white, Color.clear, 2);
			}
			if (!Instance.Fading) { return; }

			float x = Instance.t / Instance.Duration;
			Instance.SwatchTexture.color = Color.Lerp(Instance.StartColor, Instance.EndColor, x);

			Instance.t += Time.deltaTime;
			Debug.Log("t is " + Instance.t);

			if (Instance.t >= Instance.Duration) {
				Instance.Fading = false;
				Instance.SwatchTexture.enabled = false;
			}
		}

		public void Fade(Color start, Color end, float duration = 1)
		{
			Debug.Log("Start fading from: " + start + " to " + end);
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
