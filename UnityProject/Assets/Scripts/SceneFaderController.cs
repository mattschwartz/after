using UnityEngine;
using System.Collections;

public class SceneFaderController : MonoBehaviour
{
    public float FadeRate;
    public string NextLevel;
    public GUITexture guiTexture;

    // Use this for initialization
    void Start()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        guiTexture.enabled = true;
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        guiTexture.enabled = true;
        // Lerp the colour of the texture between itself and black.
        while (true) {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.black, FadeRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a >= .95) {
                guiTexture.color = Color.black;
                if (string.IsNullOrEmpty(NextLevel))
                    Application.Quit();
                else
                    Application.LoadLevel(NextLevel);
                break;
            }
        }
    }

    public IEnumerator FadeIn()
    {
        while (true) {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, FadeRate * Time.deltaTime);
            yield return null;
            if (guiTexture.color.a <= .05) {
                guiTexture.color = Color.clear;
                guiTexture.enabled = false;
                break;
            }
        }
    }
}
