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
        public List<Transition> TransitionScripts;

        #endregion

        public virtual void Interact()
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

            newState = newState ?? CurrentState;

            // Lookup transition hook for (currentstate, newstate) transition
            StartCoroutine(ReadTransition(CurrentState, (StateType)newState));

            CurrentState = (StateType)newState;
        }

        protected IEnumerator ReadTransition(StateType from, StateType to)
        {
            foreach (var script in TransitionScripts.FindAll(t => t.Legible(from, to))) {
                script.Read(from, to);
                if (script.DestroyOnRead) {
                    TransitionScripts.Remove(script);
                }
                Debug.Log("waiting for " + script.WaitSecondsAfterRead);
                yield return new WaitForSeconds(script.WaitSecondsAfterRead);
            }
        }
    }
}
