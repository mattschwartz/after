using UnityEngine;
using System.Collections;

// This file contains all sewer level animations for the player object
public class SewerLevelAnimationController : MonoBehaviour 
{
	#region Public Members

	public PlayerController PlayerController;

	#endregion

	#region Private Members

	private Animator Animator;

	#endregion

	void Start() 
	{
		Animator = GetComponent<Animator>();
	}

	public void OpenDesk(Vector3 position)
	{
		transform.position = new Vector2(position.x, transform.position.y);
		Animator.SetTrigger("OpenDesk");
	}

	#region Temporary Message Methods

    public void ShowHeldItem()
    {
        PlayerController.HeldItem.SendMessage("ShowItemHeld");
    }

    public void ShowDroppedItem()
    {
        PlayerController.HeldItem.SendMessage("ShowItemDropped");
    }

    #endregion
}
