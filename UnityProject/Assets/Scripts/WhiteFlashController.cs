using UnityEngine;
using System.Collections;

public class WhiteFlashController : MonoBehaviour {
	public float FlashRate;
	public GUITexture guiTexture;

	// Use this for initialization
	void Start () {
		// Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        guiTexture.color = Color.clear;
        guiTexture.enabled = false;
	}

	public IEnumerator Flash ()
	{
        yield return new WaitForSeconds(2);
        guiTexture.enabled = true;
		// Lerp the colour of the texture between itself and white, then back to clear.
        while (true)
        {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.white, FlashRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a >= .95)
            {
                guiTexture.color = Color.white;
                break;
            }
        }
        while (true)
        {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, FlashRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a <= .05)
            {
                guiTexture.color = Color.clear;
                break;
            }
        }
        guiTexture.enabled = false;
	}
}
