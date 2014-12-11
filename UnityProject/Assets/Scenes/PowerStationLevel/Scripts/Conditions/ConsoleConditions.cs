using After.Interactable;
using UnityEngine;

namespace After.Interactable.Conditions
{
	public class ConsoleConditions : RequiredItemConditions
	{
		public string ServerOffObservations;
		public string ItemNotFoundObservations;
		public InteractableController ServerInteractable;
        public InteractableController CrateInteractable;
		public ObservationsController Observations;

		public override bool ConditionsMet()
		{
			if (ServerInteractable.CurrentState != StateType.Unlocked) {
				Observations.SetThought(ServerOffObservations);
				return false;
			}

			if (CrateInteractable.CurrentState != StateType.Unlocked) {
				Observations.SetThought(ItemNotFoundObservations);
				return false;
			}

			return true;
		}
	}
}
