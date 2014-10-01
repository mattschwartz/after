using After.Interactable.Transitions;
using Assets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableController : MonoBehaviour
    {
        #region Members

        public StateType CurrentState { get; private set; }
        public InteractableState LockedState;
        public InteractableState UnlockedState;
        public List<Transition> TransitionScripts;

        #endregion

        void Start()
        {
            CurrentState = StateType.Locked;
        }

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

            // Lookup transition hook for (currentstate, newstate) transition
            ReadTransition(CurrentState, (StateType)newState);

            CurrentState = (StateType)newState;
        }

        protected void ReadTransition(StateType from, StateType to)
        {
            TransitionScripts
                .FindAll(t => t.Legible(from, to))
                .ForEach(t => t.Read(from, to));
        }
    }
}
