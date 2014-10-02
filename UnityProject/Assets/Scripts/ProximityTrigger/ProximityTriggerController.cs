using After.Interactable;
using After.Interactable.Transitions;
using System.Collections.Generic;
using UnityEngine;

namespace After.ProximityTrigger
{
    public class ProximityTriggerController : MonoBehaviour
    {
        #region Members

        public StateType CurrentState = StateType.Locked;
        public ProximityState Locked;
        public ProximityState Unlocked;
        public ProximityState Spent;
        public List<Transition> TransitionScripts;

        enum TriggerType
        {
            Enter,
            Remain,
            Exit
        }

        #endregion

        #region Triggers

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name != "Player") { return; }
            Trigger(TriggerType.Enter, other);
        }

        void OnTriggerRemain2D(Collider2D other)
        {
            if (other.name != "Player") { return; }
            Trigger(TriggerType.Remain, other);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.name != "Player") { return; }
            Trigger(TriggerType.Exit, other);
        }

        private void Trigger(TriggerType type, Collider2D other)
        {
            StateType? newState;
            ProximityState state = null;

            switch (CurrentState) {
                case StateType.Locked:
                    state = Locked;
                    break;
                case StateType.Unlocked:
                    state = Unlocked;
                    break;
                case StateType.Spent:
                    state = Spent;
                    break;
            }

            switch (type) {
                case TriggerType.Enter:
                    newState = state.OnEnter(other);
                    break;
                case TriggerType.Remain:
                    newState = state.OnRemain(other);
                    break;
                case TriggerType.Exit:
                    newState = state.OnExit(other);
                    break;
                default:
                    newState = null;
                    break;
            }

            newState = newState ?? CurrentState;
            ReadTransition(CurrentState, (StateType)newState);
            CurrentState = (StateType)newState;
        }

        #endregion

        protected void ReadTransition(StateType from, StateType to)
        {
            TransitionScripts
                .FindAll(t => t.Legible(from, to))
                .ForEach(t => {
                    if (!t.Read(from, to)) {
                        TransitionScripts.Remove(t);
                    }
                });
        }

    }
}
