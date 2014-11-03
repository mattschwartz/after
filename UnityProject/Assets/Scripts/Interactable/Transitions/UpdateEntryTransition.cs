using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using After.Journal;

namespace After.Interactable.Transitions
{
    public class UpdateEntryTransition : Transition
    {
        public string EntryName;
        public string Update;

        public override void Read(StateType fromState, StateType toState)
        {
            JournalController.Instance.UpdateEntry(EntryName, Update);
        }
    }
}
