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
        public float TextureSize = 550;
        public string Title;
        public string Description;
        public Texture InspectableTexture;
        public InspectorController Inspector;

        public override void Read(StateType fromState, StateType toState)
        {
            Inspector.InspectItem(Title, Description, InspectableTexture, TextureSize);
        }
    }
}
