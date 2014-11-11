using After.Interactable.Transitions;
using After.Interactable;
using UnityEngine;
using System.Collections;

namespace After.Interactable.Transitions
{
    public class InspectionViewTransition : Transition
    {
        #region Members

        public bool AddToJournal;
        public float ScreenSize;
        public string Title;
        public string Observations;
        public Texture InspectingTexture;

        #endregion

        public override void Read(StateType fromState, StateType toState)
        {
            float size = (ScreenSize / 100f) * (float)Screen.width;
            InspectorController.Instance.InspectItem(Title, Observations, InspectingTexture, size, AddToJournal);
        }
    }
}
