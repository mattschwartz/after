using After.Interactable;
using After.Interactable.Transitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using After.ProximityTrigger.ProximityTransitions;
using UnityEngine;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class TeleportProximityTransition : ProximityTransition
    {
        #region Members

        public GameObject ExitNexus;
        public GameObject Player;
        public SpriteRenderer NewSpriteBounds;

        #endregion

        public override void Read(StateType fromState, StateType toState)
        {
            MovePlayer();
        }

        protected void MovePlayer()
        {
            Camera.main.SendMessage("SetSpriteBounds", NewSpriteBounds);
            Player.transform.position = ExitNexus.transform.position;
        }
    }
}
