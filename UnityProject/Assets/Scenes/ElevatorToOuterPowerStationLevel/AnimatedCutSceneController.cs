using UnityEngine;
using After.Audio;
using System.Collections;

public class AnimatedCutSceneController : MonoBehaviour
{
    #region Members

    public SceneFaderController Fader;
    public float Duration;
    public Animator Animator;
    public AudioClip StopClip;

    private bool Arrived = false;
    private float Tick = 0f;

    #endregion

    void Update()
    {
        Tick += Time.deltaTime;

        if (Arrived) { return; }

        if (Input.GetKeyDown(KeyCode.Escape) || Tick >= Duration) {
            if (Tick >= Duration) {
                Animator.SetTrigger("Stop");

                if (StopClip) {
                    AudioManager.PlayClipAtPoint(StopClip, transform.position);
                }
            }

            Arrived = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        if (StopClip) {
            yield return new WaitForSeconds(StopClip.length);
        } else {
            yield return 0;
        }

        StartCoroutine(Fader.FadeOut());
    }
}