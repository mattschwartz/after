using UnityEngine;
using System.Collections;

public class SewerGrateController : MonoBehaviour {

    private bool On = false;
    private Animator Anim;
    private BoxCollider2D WaterCollider;

    void Start()
    {
        Anim = GetComponent<Animator>();
        WaterCollider = GetComponent<BoxCollider2D>();
        WaterCollider.enabled = false;
    }

    public void Toggle()
    {
        var clip = GetComponent<AudioSource>();
        On = !On;

        Anim.SetBool("On", On);

        if (On) {
            clip.Play();
            WaterCollider.enabled = true;
        } else {
            clip.Pause();
            WaterCollider.enabled = false;
        }
    }
}
