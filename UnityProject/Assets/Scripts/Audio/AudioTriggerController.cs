using UnityEngine;
using System.Collections;
using After.Audio;

public class AudioTriggerController : MonoBehaviour 
{
	public bool StopOnExit = false;
    public bool DestroyOnExit = true;
	public AudioClip Clip;

	void OnTriggerEnter2D(Collider2D other) 
	{
        AudioManager.PlayClipAtPoint(Clip, transform.position);
        OnEnter();
	}

	void OnTriggerExit2D(Collider2D other)
	{
        OnExit();

        if (DestroyOnExit) {
            Destroy(gameObject, Clip.length);
            return;
        }

		if (StopOnExit) {
		}
	}

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
}
