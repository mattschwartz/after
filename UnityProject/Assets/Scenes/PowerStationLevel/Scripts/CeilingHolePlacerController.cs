using UnityEngine;
using System.Collections;
using Assets.Scripts.Utility;

public class CeilingHolePlacerController : MonoBehaviour
{

    #region Members

    public float LeftPositionBounds;
    public float RightPositionBounds;
    public SpriteRenderer CeilingHole;

    #endregion

    void Start()
    {
        CeilingHole.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (CeilingHole.enabled) { return; }

        float x = other.transform.position.x;

        if (x < LeftPositionBounds
            || x > RightPositionBounds) { return; }

        CeilingHole.enabled = true;
        CeilingHole.transform.position = new Vector3(other.transform.position.x, CeilingHole.transform.position.y);
    }
}
