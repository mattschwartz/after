using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandleController : MonoBehaviour
{

    public GameObject ButtonObject;
    public List<GameObject> SewerGrateObjects;

    private bool Entered = false;
    private Animator Animator;
    private List<AudioSource> AudioSources;

    void Start()
    {
        Animator = GetComponent<Animator>();
        AudioSources = new List<AudioSource>(GetComponents<AudioSource>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Entered = true;

        Vector3 buttonPosition = ButtonObject.transform.position;
        buttonPosition.x = transform.position.x;
        buttonPosition.y = transform.position.y + 1;

        ButtonObject.transform.position = buttonPosition;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;

        Vector3 buttonPosition = ButtonObject.transform.position;
        buttonPosition.x = -5000;
        buttonPosition.y = -5000;

        ButtonObject.transform.position = buttonPosition;
    }

    void Update()
    {
        if (Entered && Input.GetKeyDown(KeyCode.E)) {
            foreach (var sewerGrate in SewerGrateObjects) {
                PlayRandomSound();
                Animator.SetTrigger("TurnOn");
                sewerGrate.SendMessage("Toggle");
            }
        }
    }

    private void PlayRandomSound()
    {
        foreach (var source in AudioSources) {
            source.Stop();
        }

        System.Random ran = new System.Random();
        int index = ran.Next(4);
        var audioSource = AudioSources[index];
        audioSource.Play();
    }
}
