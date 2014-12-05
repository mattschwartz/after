using UnityEngine;
using After.Audio;
using System.Collections;
using After.Scene.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    #region Members

    public SceneFaderController Fader;
    public float Duration;
    public GameObject MobilePrompt;
    public GameObject OtherPrompt;

    private float Tick = 0f;

    #endregion

    void Start()
    {
        if (SceneHandler.OnMobile) {
            Destroy(OtherPrompt);
        } else {
            Destroy(MobilePrompt);
        }
    }

    void Update()
    {
        Tick += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) || Tick >= Duration) {
            StartCoroutine(Fader.FadeOut());
		}
	}
}
