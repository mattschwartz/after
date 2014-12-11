using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;
using System.Collections;

namespace After.Interactable.Transitions
{
    public class InspectionTransition : Transition
    {
        #region Members

        public bool AddToJournal;
        public float PercentSize;
        public string Title;
        public string Observations;
        public Texture InspectingTexture;

        #endregion

        public override void Read(StateType fromState, StateType toState)
        {
            float size = (PercentSize / 100f) * Screen.width;

            InspectorController.Instance.InspectItem(Title, Observations, InspectingTexture, size, AddToJournal);
        }
    }
}
