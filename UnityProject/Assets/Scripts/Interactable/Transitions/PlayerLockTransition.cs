using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public abstract class PlayerLockTransition : Transition
    {
        public float LockDuration = 0f;
        public GameObject Player;
        public Animator PlayerAnimator;

        protected void FreePlayer()
        {
            Player.SendMessage("FreePlayer");
        }
    }
}
