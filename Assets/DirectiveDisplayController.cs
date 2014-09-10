using UnityEngine;
using System.Collections;

public class DirectiveDisplayController : MonoBehaviour {

    public GameObject Directive;

    void Start()
    {
        Directive.transform.position = new Vector2(-5000, -5000);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var pos = transform.position;
        Directive.transform.position = new Vector2(pos.x, pos.y + 1);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Directive.transform.position = new Vector2(-5000, -5000);
    }
}
