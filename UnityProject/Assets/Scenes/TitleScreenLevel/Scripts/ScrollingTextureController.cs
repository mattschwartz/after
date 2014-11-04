using UnityEngine;
using System.Collections;

public class ScrollingTextureController : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public Vector2 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = StartPosition + Vector2.up * newPosition;
    }
}
