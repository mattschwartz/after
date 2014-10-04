using UnityEngine;
using System.Collections;

public class SceneFaderController : MonoBehaviour {
	public float FadeRate;
	public int NextLevel;
	private bool FadingOut;
	private bool FadingIn;

	// Use this for initialization
	void Start () {
		FadingOut = false;
		FadingIn = true;
		// Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void FadeOut ()
	{
		FadingOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (FadingOut)
		{
			// Lerp the colour of the texture between itself and black.
        	guiTexture.color = Color.Lerp(guiTexture.color, Color.black, FadeRate * Time.deltaTime);
        	if (guiTexture.color.a <= .95f)
        	{
        		if (NextLevel == 0)
        			Application.Quit();
        		Application.LoadLevel(NextLevel);
        	}
		}
		else if (FadingIn)
		{
			// Lerp the colour of the texture between itself and transparent.
        	guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, FadeRate * Time.deltaTime);
        	if (guiTexture.color.a <= .05f)
        		FadingIn = false;
		}
	}
}
