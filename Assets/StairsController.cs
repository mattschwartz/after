using UnityEngine;
using System.Collections;

public class StairsController : MonoBehaviour {

    public float Height;
    public GameObject PlayerObject;
    private bool Entered = false;
    public BoxCollider2D Top;
    public BoxCollider2D StepCollision;

    void Start()
    {
        Top.enabled = true;
        StepCollision.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Entered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Entered && Input.GetKeyDown(KeyCode.E))
        {
            Top.enabled = false;
            StepCollision.enabled = true;
        }
    }
}
