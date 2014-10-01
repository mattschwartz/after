using UnityEngine;
using System.Collections;
using After.Interactable;

public class SoulProximityController : InteractableController 
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name == "Player") {
			Interact();
		}
	}

	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.name == "Player") {
			other.SendMessage("SoulNearby");
		}
	}

	void Update()
	{
		// if (SoulController.CurrentState == StateType.Spent) {
			// no more showing
		// }
	}

	public override void Interact() 
	{
		// can't interact since it's proximity-based
	}
}
