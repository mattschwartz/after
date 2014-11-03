using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using After.Interactable;
using After.Interactable.Transitions;
using After.Journal;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class UpdateJournalProximityTransition : ProximityTransition
    {
        public string Title;
        public string Update;
        public Texture Image;

        public override void Read(StateType fromState, StateType toState)
        {
            var entry = new Entry(Title, Update, Image);

            JournalController.Instance.AddEntry(entry);
        }
    }
}
