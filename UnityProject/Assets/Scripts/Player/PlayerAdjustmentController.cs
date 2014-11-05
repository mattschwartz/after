using UnityEngine;
using System.Collections;

public class PlayerAdjustmentController : MonoBehaviour
{
    #region Members

    public float NewSpeed;
    public float NewJumpForce;
    public Vector2 NewScale;
    public PlayerController Player;

    private float OldSpeed;
    private float OldJumpForce;
    private Vector2 OldScale;

    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            var scale = other.transform.localScale;
            OldScale = new Vector2(Mathf.Abs(scale.x), scale.y);
            OldSpeed = Player.Speed;
            OldJumpForce = Player.JumpForce;

            other.transform.localScale = new Vector2(NewScale.x * Mathf.Sign(scale.x), NewScale.y);
            Player.Speed = NewSpeed;
            Player.JumpForce = NewJumpForce;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            var scale = other.transform.localScale;
            other.transform.localScale = new Vector2(OldScale.x * Mathf.Sign(scale.x), OldScale.y);

            Player.Speed = OldSpeed;
            Player.JumpForce = OldJumpForce;
        }
    }
}
