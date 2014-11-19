using UnityEngine;
using System.Collections;

public class PowerCapsuleController : MonoBehaviour {

    public BoxCollider2D PlayerBox;
    public CircleCollider2D PlayerCircle;
    public BoxCollider2D CapsuleBox;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(CapsuleBox, PlayerBox);
        Physics2D.IgnoreCollision(CapsuleBox, PlayerCircle);
	}
}
