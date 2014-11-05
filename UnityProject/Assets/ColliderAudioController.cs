using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;

public class ColliderAudioController : MonoBehaviour
{
    public float Volume = 1;
    public GameObject WatchFor;
    public List<AudioClip> AudioClips;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == WatchFor.name) {
            AudioClips.ForEach(t => AudioManager.PlayClipAtPoint(t, transform.position, Volume));
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == WatchFor.name) {
            AudioClips.ForEach(t => AudioManager.PlayClipAtPoint(t, transform.position, Volume));
            Destroy(this.gameObject);
        }
    }
}
