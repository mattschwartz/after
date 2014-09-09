using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform FollowTarget;
    public SpriteRenderer spriteBounds;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    private float leftBound, rightBound, bottomBound, topBound;

    void Start()
    {
        float vertExtent = Camera.main.camera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        leftBound = (float)(horzExtent - spriteBounds.sprite.bounds.size.x / 2.0f);
        rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
        bottomBound = (float)(vertExtent - spriteBounds.sprite.bounds.size.y / 2.0f);
        topBound = (float)(spriteBounds.sprite.bounds.size.y / 2.0f - vertExtent);
    }
	
	void Update () {
        Vector3 point = camera.WorldToViewportPoint(FollowTarget.position);
        Vector3 delta = FollowTarget.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        Vector3 destination = transform.position + delta;

        // Camera move damp effect        
        var pos = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
        
        transform.position = pos;

        // no damp effect
        //transform.position = new Vector3(FollowTarget.position.x, transform.position.y, transform.position.z);
	}
}
