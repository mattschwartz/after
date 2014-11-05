using After.Interactable;
using After.Journal;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class AddEntryTransition : Transition
    {
        public string EntryName;
        public string Update;
        public Texture Image;

        public override void Read(StateType fromState, StateType toState)
        {
            var entry = new Entry(EntryName, Update, Image);
            JournalController.Instance.AddEntry(entry);
        }
    }
}
