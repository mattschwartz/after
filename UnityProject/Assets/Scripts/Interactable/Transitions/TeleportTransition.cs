using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class TeleportTransition : Transition
    {
        #region Members

        public Vector3 ToLocation;
        public GameObject Player;
        public SpriteRenderer NewSpriteBounds;

        #endregion

        public override bool Read(StateType fromState, StateType toState)
        {
            MovePlayer();

            return true;
        }

        protected void MovePlayer()
        {
            Camera.main.SendMessage("SetSpriteBounds", NewSpriteBounds);
            Player.transform.position = ToLocation;
        }
    }
}
