﻿using System;
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
        public bool LockPlayer = true;
        public bool MovePlayer = false;
        public string Trigger;
        public Vector2 Offset;

        public override void Read(StateType fromState, StateType toState)
        {
            if (MovePlayer) {
                var pos = Player.transform.position;
                Player.transform.position = new Vector2(pos.x - Offset.x, pos.y - Offset.y);
            }

            if (LockPlayer) {
                Player.SendMessage("LockPlayer");
                Invoke("FreePlayer", LockDuration);
            }

            PlayerAnimator.SetTrigger(Trigger);
        }
    }
}
