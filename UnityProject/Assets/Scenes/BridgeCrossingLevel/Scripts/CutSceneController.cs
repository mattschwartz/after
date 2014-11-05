using UnityEngine;
using After.Audio;
using System.Collections;

public class CutSceneController : MonoBehaviour
{
    #region Members

    public SceneFaderController Fader;
    public float Duration;

    private float Tick = 0f;

    #endregion

    void Update()
    {
        Tick += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) || Tick >= Duration) {
            StartCoroutine(Fader.FadeOut());
		}
	}
}
