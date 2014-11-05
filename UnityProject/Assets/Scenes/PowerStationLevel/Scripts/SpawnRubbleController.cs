using UnityEngine;
using System.Collections;

public class SpawnRubbleController : MonoBehaviour
{
    public Rigidbody2D Rubble;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Player") { return; }

        Rubble.gravityScale = 8;

        Destroy(this.gameObject);
    }
}
