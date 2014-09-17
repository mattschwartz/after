using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    #region Public Members

    public bool StaticCamera = false;
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
        CalculateBounds();
    }

    void Update()
    {
        if (StaticCamera || FollowTarget == null) {
            return;
        }

        Vector3 point = camera.WorldToViewportPoint(FollowTarget.position);
        Vector3 delta = FollowTarget.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;

        var pos = Vector3.SmoothDamp(transform.position, destination, ref Velocity, DampTime);


        pos.x = Mathf.Clamp(pos.x, LeftBounds, RightBounds);
        pos.y = Mathf.Clamp(pos.y, BottomBounds, TopBounds);

        transform.position = pos;
    }

    void CalculateBounds()
    {
        float vertExtent = Camera.main.camera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        float horzScale = SpriteBounds.transform.localScale.x;
        float vertScale = SpriteBounds.transform.localScale.y;

        LeftBounds = (float)(horzExtent - (SpriteBounds.sprite.bounds.size.x * horzScale) / 2.0f) + SpriteBounds.transform.position.x;
        RightBounds = (float)((SpriteBounds.sprite.bounds.size.x * horzScale) / 2.0f - horzExtent) + SpriteBounds.transform.position.x;
        BottomBounds = (float)(vertExtent - (SpriteBounds.sprite.bounds.size.y * vertScale) / 2.0f) + SpriteBounds.transform.position.y;
        TopBounds = (float)((SpriteBounds.sprite.bounds.size.y * vertScale) / 2.0f - vertExtent) + SpriteBounds.transform.position.y;
    }

    public void SetStaticCamera(bool value)
    {
        StaticCamera = value;
    }

    public void SetSpriteBounds(SpriteRenderer spriteBounds)
    {
        SpriteBounds = spriteBounds;
        CalculateBounds();
    }
}