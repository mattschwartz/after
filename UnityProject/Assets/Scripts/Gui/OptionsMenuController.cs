using System.Collections;
using After.Audio;
using UnityEngine;

namespace After.Gui
{
	public class OptionsMenuController : MonoBehaviour
	{
		#region Members

		public float hSliderValue;
		public GUIStyle opaCustomStyle;
		public GUIStyle SliderStyle;
		public GUIStyle SliderThumbStyle;

		private KeyCode kcOkay = KeyCode.Return;
		private KeyCode kcCancel = KeyCode.Escape;
		private Rect SoundSliderBounds;
		private Rect btnBoundsOK;
		private Rect btnBoundsCancel;

		#endregion

		void Start()
		{
			Resize();
		}

		void Update()
		{
			ProcessKeyboard();
			ProcessMouse();
			Resize();
			AudioManager.SetVolume(hSliderValue / 100f);
		}

		private void ProcessKeyboard()
		{

		}

		private void ProcessMouse()
		{

		}

		private void Resize()
		{
            var screenCoords = new Vector3(0.5f, 0.5f, 0);
            var camPos = Camera.main.ViewportToScreenPoint(screenCoords);

			SoundSliderBounds = new Rect {
				x = camPos.x,
				y = camPos.y,
				width = 250,
				height = 25
			};	
		}

		void OnGui()
		{
			hSliderValue = GUI.HorizontalSlider(SoundSliderBounds, 
				hSliderValue, 0, 100, SliderStyle, SliderThumbStyle);

			GUI.Label(btnBoundsOK, "[Enter] Apply", opaCustomStyle);
			GUI.Label(btnBoundsCancel, "[Escape] Cancel", opaCustomStyle);
		}
	}
}
