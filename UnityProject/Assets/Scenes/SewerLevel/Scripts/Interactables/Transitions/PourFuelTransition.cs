using After.Interactable;
using After.Interactable.Transitions;
using After.Scene.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PourFuelTransition : Transition
{
    public GameObject Player;
    public GameObject RequiredItem;

    public override bool Read(StateType fromState, StateType toState)
    {
        string itemHeld = SceneHandler.CurrentPlayer.ItemHeld;
        bool playerHasItem = (RequiredItem && itemHeld == RequiredItem.name);

        if (!playerHasItem) {
            return true;
        }

        Player.transform.position = new Vector2(transform.position.x, transform.position.y);
        Player.SendMessage("LockPlayer");
        Invoke("FreePlayer", 1f);
        Player.GetComponent<Animator>().SetTrigger("PourFuel");

        return false;
    }
}
