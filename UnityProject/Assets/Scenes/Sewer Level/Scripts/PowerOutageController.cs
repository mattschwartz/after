using UnityEngine;
using System.Collections;

public class PowerOutageController : MonoBehaviour
{
    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
