using UnityEngine;
using System.Collections;

public class SewerGrateController : MonoBehaviour {

    public bool On = false;
    private AudioSource AudioSource;
    private Animator Anim;
    private BoxCollider2D WaterCollider;

    void Start()
    {
        Anim = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        WaterCollider = GetComponent<BoxCollider2D>();
        WaterCollider.enabled = false;

        if (On) {
            TurnOn();
        } else {
            TurnOff();
        }
    }

    private void TurnOn() {
        Anim.SetBool("On", true);
        AudioSource.Play();
        WaterCollider.enabled = true;
    }

    private void TurnOff() {
        Anim.SetBool("On", false);
        AudioSource.Stop();
        WaterCollider.enabled = false;
    }

    public void Toggle()
    {
        On = !On;

        if (On) {
            TurnOn();
        } else {
            TurnOff();
        }
    }
}
