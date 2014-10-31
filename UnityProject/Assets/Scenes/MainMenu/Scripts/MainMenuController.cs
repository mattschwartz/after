using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public SceneFaderController Fader;
    private KeyCode ContinueButton = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(ContinueButton)) {
            StartCoroutine(Fader.FadeOut());
        }
    }
}
