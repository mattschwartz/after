using UnityEngine;
using After.Audio;
using System.Collections;

public class CutSceneController : MonoBehaviour 
{
	public SceneFaderController Fader;
    public float Duration;
    public Animator Animator;
    public AudioClip StopClip = null;

    private bool Arrived = false;
    private float Tick = 0f;

	void Update() 
	{
		if (Arrived) {return; }

		if (Input.GetKeyDown(KeyCode.Escape) || Tick >= Duration) {
			if (Tick >= Duration) {
				Animator.SetTrigger("Stop");
                if (StopClip)
				    AudioManager.PlayClipAtPoint(StopClip, transform.position);
				StartCoroutine(LoadNextLevel());
				Arrived = true;
			}
		}
	}

    void FixedUpdate()
    {
        Tick += Time.deltaTime;
    }

	private IEnumerator LoadNextLevel()
	{
        if (StopClip)
		    yield return new WaitForSeconds(StopClip.length);
		StartCoroutine(Fader.FadeOut());
	}
}
