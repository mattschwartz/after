using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLockedConditions : RequiredItemConditions
{
    public GameObject Player;
    public GeneratorInteractableController GeneratorController;

    public override bool ConditionsMet()
    {
        if (PlayerHasItem()) {
            Player.transform.position = new Vector2(transform.position.x, transform.position.y);
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", 1f);
            Player.GetComponent<Animator>().SetTrigger("PourFuel");

            GeneratorController.FuelLevel++;
        }

        return GeneratorController.FuelLevel > 0;
    }

    public void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }
}
