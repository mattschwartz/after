using UnityEngine;
using System.Collections;

public class PlayerScalerController : MonoBehaviour
{
    public float Scale = 1.5f;
    private Vector2 OriginalTransform;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            var scale = other.transform.localScale;

            OriginalTransform = new Vector2(Mathf.Abs(scale.x), scale.y);
            other.transform.localScale = new Vector2(Scale * Mathf.Sign(scale.x), Scale);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            var scale = other.transform.localScale;
            other.transform.localScale = new Vector2(OriginalTransform.x * Mathf.Sign(scale.x), OriginalTransform.y);
        }
    }
}
