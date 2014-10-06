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
        StartCoroutine(FadeIn());
	}

	public IEnumerator FadeOut ()
	{
		// Lerp the colour of the texture between itself and black.
        while (true)
        {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.black, FadeRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a >= .95)
            {
                if (NextLevel == 0)
                    Application.Quit();
                else
                    Application.LoadLevel(NextLevel);
                break;
            }
        }
        yield return null;
	}

	public IEnumerator FadeIn ()
	{
        while (true)
        {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, FadeRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a <= .05)
                break;
        }
        yield return null;
	}
}
