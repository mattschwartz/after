using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using UnityEngine;
using After.Journal;

namespace After.Interactable.Transitions
{
    public class UpdateJournalTransition : Transition
    {
        public string Title;
        public string Update;
        public SpriteRenderer Sprite;

        public override void Read(StateType fromState, StateType toState)
        {
            var entry = new Entry(Title, Update, Sprite.sprite.texture);

            JournalController.Instance.AddEntry(entry);
        }
    }
}
