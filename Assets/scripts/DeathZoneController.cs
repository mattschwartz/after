using UnityEngine;
using System.Collections;

public class DeathZoneController : MonoBehaviour {

    private bool Killed = false;
    public Vector2 InitialPosition;
    public GameObject PlayerObject;
    private AudioSource ScreamSound;

    void Start()
    {
        ScreamSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Killed = true;
        ScreamSound.Play();
    }

    void Update()
    {
        if (Killed && Input.GetKeyDown(KeyCode.R)) {
            PlayerObject.transform.position = InitialPosition;
            Killed = false;
            ScreamSound.Stop();
        }
    }
}
