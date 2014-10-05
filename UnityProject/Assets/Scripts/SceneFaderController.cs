using UnityEngine;
using System.Collections;

public class SceneFaderController : MonoBehaviour {
	public float FadeRate;
	public int NextLevel;
	public GUITexture guiTexture;

	// Use this for initialization
	void Start () {
		// Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	public IEnumerator FadeOut ()
	{
		// Lerp the colour of the texture between itself and black.
    	guiTexture.color = Color.Lerp(guiTexture.color, Color.black, FadeRate * Time.deltaTime);
    	yield return 1.0f / FadeRate;
    	if (NextLevel == 0)
    		Application.Quit();
    	else
    		Application.LoadLevel(NextLevel);
    	yield return 0;
	}

	public IEnumerator FadeIn ()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, FadeRate * Time.deltaTime);
		yield return 1.0f / FadeRate;
	}
}
