using After.Interactable.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DeskConditions : RequiredItemConditions
{
    public GameObject Player;

    public override bool ConditionsMet()
    {
        if (PlayerHasItem()) {
            Player.transform.position = new Vector2(transform.position.x, transform.position.y);
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", 1.75f);
            Player.GetComponent<Animator>().SetTrigger("OpenDesk");

            return true;
        }

        return false;
    }

    public void FreePlayer()
    {
        Player.SendMessage("FreePlayer");
    }
}
