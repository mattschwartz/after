using UnityEngine;
using System.Collections;
using After.Audio;

public class AudioTriggerController : MonoBehaviour 
{
    public bool DestroyOnEntrance = true;
	public AudioClip Clip;

	void OnTriggerEnter2D(Collider2D other) 
	{
        AudioManager.PlayClipAtPoint(Clip, transform.position);
        OnEnter();

        if (DestroyOnEntrance) {
            Destroy(gameObject);
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
        OnExit();
	}

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
}
