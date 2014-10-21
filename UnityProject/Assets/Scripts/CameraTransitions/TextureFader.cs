using System.Collections;
using UnityEngine;

namespace After.CameraTransitions
{
	/// <summary>TextureFader is a Singleton that can be used to fade a default
	/// <para>texture or supplied texture over a specified duration</para>
	/// </summary>
	public class TextureFader : ScriptableObject
	{
		public GUITexture SwatchTexture;
		public static TextureFader Instance;

		private bool Fading = false;
		private float t;
		private float Duration;
		private Color StartColor;
		private Color EndColor;
		private Texture DefaultTexture;

		private TextureFader()
		{
		}

		void Start()
		{
			Instance = TextureFader.CreateInstance<TextureFader>();
			Instance.SwatchTexture = SwatchTexture;
	        Instance.SwatchTexture.transform.position = new Vector3(0, 0, 0);
	        Instance.SwatchTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
            Instance.SwatchTexture.enabled = false;
            Instance.DefaultTexture = Instance.SwatchTexture.texture;
		}

		void Update()
		{
			if (!Instance.Fading) { return; }

			float x = Instance.t / Instance.Duration;
			Instance.SwatchTexture.color = Color.Lerp(Instance.StartColor, Instance.EndColor, x);

			Instance.t += Time.deltaTime;

			// Cleanup
			if (Instance.t >= Instance.Duration) {
				Instance.Cleanup();
			}
		}

		/// <summary>Perform any necessary resetting of variables after the 
		/// <para>fade transition completes.</para>
		/// </summary>
		public void Cleanup()
		{
			Fading = false;
			SwatchTexture.enabled = false;
			SwatchTexture.texture = DefaultTexture;
		}

		/// <summary>Sets the texture to be faded for the next fade
		/// <param name="texture">The texture to fade</param>
		/// </summary>
		public void SetTexture(Texture texture)
		{
			SwatchTexture.texture = texture;
		}

		/// <summary>Sets the texture (from a sprite) to be faded for the next 
		/// <para>fade</para>
		/// <param name="sprite">The sprite's texture to fade</param>
		/// </summary>
		public void SetTexture(Sprite sprite)
		{
			SetTexture(sprite.texture);
		}

		/// <summary>Fade the current texture from a starting color to an
		/// <para>ending color</para>
		/// <param name="start">The beginning color of the texture</param>
		/// <param name="end">The ending color of the texture</param>
		/// <param name="duration">The length of the fade transition (default 1)</param>
		/// </summary>
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
