using UnityEngine;
using System.Collections;

public class WalkAudioController : MonoBehaviour {

    private AudioSource Clip;
    public Rigidbody2D PlayerBody;

	// Use this for initialization
	void Start () {
        Clip = GetComponent<AudioSource>();
        PlayerBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        var vel = PlayerBody.velocity.magnitude;

        if (vel > 0.01) {
            if (!Clip.isPlaying) {
                Clip.Play();
            }
        } else {
            Clip.Pause();
        }
    }
}
