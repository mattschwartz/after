using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    #region Public Members

    public Transform FollowTarget;
    public SpriteRenderer SpriteBounds;

    #endregion

    #region Private Members

    public float DampTime = 0.15f;
    private Vector3 Velocity = Vector3.zero;
    private float LeftBounds; 
    private float RightBounds; 
    private float BottomBounds;
    private float TopBounds;

    #endregion

    void Start()
    {
        float vertExtent = Camera.main.camera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        LeftBounds = (float)(horzExtent - SpriteBounds.sprite.bounds.size.x / 2.0f);
        RightBounds = (float)(SpriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);
        BottomBounds = (float)(vertExtent - SpriteBounds.sprite.bounds.size.y / 2.0f);
        TopBounds = (float)(SpriteBounds.sprite.bounds.size.y / 2.0f - vertExtent);
    }

    void Update()
    {
        Vector3 point = camera.WorldToViewportPoint(FollowTarget.position);
        Vector3 delta = FollowTarget.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;

        var pos = Vector3.SmoothDamp(transform.position, destination, ref Velocity, DampTime);
        pos.x = Mathf.Clamp(pos.x, LeftBounds, RightBounds);
        pos.y = Mathf.Clamp(pos.y, BottomBounds, TopBounds);

        transform.position = pos;
    }
}