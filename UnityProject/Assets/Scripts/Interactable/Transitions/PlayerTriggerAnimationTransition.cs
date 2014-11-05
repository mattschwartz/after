using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class PlayerTriggerAnimationTransition : PlayerLockTransition
    {
        public float xOffset = 4;
        public string Trigger;

        public override void Read(StateType fromState, StateType toState)
        {
            Player.transform.position = new Vector2(transform.position.x - xOffset, transform.position.y);
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", LockDuration);

            PlayerAnimator.SetTrigger(Trigger);
        }
    }
}
