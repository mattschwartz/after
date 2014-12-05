using UnityEngine;
using System.Collections;
using System.Linq;

public class DisableColliderController : MonoBehaviour 
{
    public SpriteRenderer SRenderer;
    public GameObject WatchFor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == WatchFor) {
            WatchFor.layer = LayerMask.NameToLayer("PlayerIgnores");
            SRenderer.sortingLayerName = "Default";
        }
    }
}
