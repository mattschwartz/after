using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GeneratorUnlockedConditions : RequiredItemConditions
{
    public GameObject Player;
    public GeneratorInteractableController GeneratorController;

    public override bool ConditionsMet()
    {
        // Consume fuel if player has it
        if (PlayerHasItem()) {
            Player.transform.position = new Vector2(transform.position.x, transform.position.y);
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", 2.4f);
            Player.GetComponent<Animator>().SetTrigger("PourFuel");

            GeneratorController.FuelLevel++;
        }

        // Can't leave unlocked state
        return true;
    }

    public void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }
}
