using After.Interactable.Transitions;
using Assets.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable
{
    public class InteractableController : MonoBehaviour
    {
        #region Members

        public StateType CurrentState = StateType.Locked;
        public InteractableState LockedState;
        public InteractableState UnlockedState;
        public InteractableState SpentState;
        public List<Transition> TransitionScripts;

        #endregion

        public virtual void Interact()
        {
            StateType? newState = null;

            switch (CurrentState) {
                case StateType.Locked:
                	if (LockedState != null) {
	                    newState = LockedState.Transition();
                	}
                    break;
                case StateType.Unlocked:
                	if (UnlockedState != null) {
	                    newState = UnlockedState.Transition();
                	}
                    break;
                case StateType.Spent:
                	if (SpentState != null) {
	                	newState = SpentState.Transition();
                	}
                	break;
            }

            newState = newState ?? CurrentState;

            // Lookup transition hook for (currentstate, newstate) transition
            ReadTransitions(CurrentState, (StateType)newState);

            CurrentState = (StateType)newState;
        }

        protected void ReadTransitions(StateType from, StateType to)
        {
            foreach (var script in TransitionScripts.FindAll(t => t.Legible(from, to))) {
                StartCoroutine(Read(script, from, to));

                if (script.DestroyOnRead) {
                    TransitionScripts.Remove(script);
                }
            }
        }

        private IEnumerator Read(Transition script, StateType from, StateType to)
        {
            yield return new WaitForSeconds(script.WaitSecondsBeforeRead);
            script.Read(from, to);
        }
    }
}
