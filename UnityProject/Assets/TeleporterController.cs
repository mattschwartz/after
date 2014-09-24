using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour 
{
	#region Public Members

    public Vector3 ToLocation;
    public GameObject Player;
    public SpriteRenderer NewSpriteBounds;

	#endregion

	void OnTriggerEnter2D(Collider2D other)
	{
        if (NewSpriteBounds != null) {
            Camera.main.SendMessage("SetSpriteBounds", NewSpriteBounds);
        }
        Player.transform.position = ToLocation;
	}
}
