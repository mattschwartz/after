using UnityEngine;
using After.Audio;
using System.Collections;

public class CutSceneController : MonoBehaviour 
{
	public SceneFaderController Fader;
    public float Duration;
    public Animator Animator;
    public AudioClip StopClip;

    private bool Arrived = false;
    private float Tick;

	void Update() 
	{
		if (Arrived) {return; }

        Tick += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Escape) || Tick >= Duration) {
			if (Tick >= Duration) {
				Animator.SetTrigger("Stop");
				AudioManager.PlayClipAtPoint(StopClip, transform.position);
				StartCoroutine(LoadNextLevel());
				Arrived = true;
			}
		}
	}

	private IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds(StopClip.length);
		StartCoroutine(Fader.FadeOut());
	}
}
