using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using After.Interactable;

namespace After.Interactable.Transitions
{
    public class InspectableTransition : Transition
    {

        #region Members

        public bool AddToJournal = true;
        public float TextureSize = 550;
        public string Title;
        public string Description;
        public Texture InspectableTexture;

        #endregion

        public override void Read(StateType fromState, StateType toState)
        {
            InspectorController.Instance.InspectItem(Title, Description, InspectableTexture, TextureSize, AddToJournal);
        }
    }
}
