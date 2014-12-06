using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class PlayerLockTransition : Transition
    {
        public float LockDuration = 0f;
        public GameObject Player;
        public Animator PlayerAnimator;

        protected virtual void FreePlayer()
        {
            Player.SendMessage("FreePlayer");
        }

        public override void Read(StateType fromState, StateType toState)
        {
            Player.SendMessage("LockPlayer");
            Invoke("FreePlayer", LockDuration);
        }
    }
}
