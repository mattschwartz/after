using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public abstract class Transition : MonoBehaviour
    {
        #region Members

        public StateType From;
        public StateType To;

        #endregion

        public bool Legible(StateType from, StateType to)
        {
            if (From == StateType.Any) {
                from = StateType.Any;
            }

            if (To == StateType.Any) {
                to = StateType.Any;
            }

            return From == from && To == to;
        }
        public abstract void Read(StateType fromState, StateType toState);
    }
}
