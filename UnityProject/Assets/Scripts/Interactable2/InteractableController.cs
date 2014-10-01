using Assets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Interactable
{
    public class InteractableController : MonoBehaviour
    {
        #region Members

        public StateType CurrentState { get; private set; }
        public InteractableState LockedState;
        public InteractableState UnlockedState;
        public List<Transition> TransitionScripts;

        #endregion

        public void Interact()
        {
            StateType? newState = null;

            switch (CurrentState) {
                case StateType.Locked:
                    newState = LockedState.Transition();
                    break;
                case StateType.Unlocked:
                    newState = UnlockedState.Transition();
                    break;
            }

            newState = newState == null ? CurrentState : newState;
            CurrentState = (StateType)newState;

            // Lookup transition hook for (currentstate, newstate) transition
            ReadTransition(CurrentState, (StateType)newState);
        }

        private void ReadTransition(StateType from, StateType to)
        {
            TransitionScripts
                .FindAll(t => t.From == from && t.To == to)
                .ForEach(t => t.Read());
        }
    }
}
