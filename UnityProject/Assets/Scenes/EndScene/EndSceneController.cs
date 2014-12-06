using UnityEngine;
using System.Collections;

public class EndSceneController : MonoBehaviour
{
    public SceneFaderController Fader;

    public void LoadNextLevel()
    {
        StartCoroutine(Fader.FadeOut());
    }
}
