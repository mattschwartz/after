using UnityEngine;
using System.Collections;

public class BreakableDoorController : MonoBehaviour {

    public GameObject Target;
    public BoxCollider2D DoorCollide;
    public SpriteRenderer Sprite;
    private bool Triggered;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Target && !Triggered)
        {
            DoorCollide.isTrigger = true;
            Sprite.sortingLayerName = "Background";
            Sprite.sortingOrder = 0;
            Triggered = true;
        }
    }

	// Use this for initialization
	void Start () {
        Triggered = false;
	}
}
