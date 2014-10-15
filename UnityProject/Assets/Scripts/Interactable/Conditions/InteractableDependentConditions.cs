using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using After.Interactable;

/*
 * For states that are met when another Interactable is in a specified state.
 */
namespace After.Interactable.Conditions
{
	public class InteractableDependentConditions : InteractableConditions
	{
		public InteractableController DependentInteractable;
		public StateType RequiredState;

		public override bool ConditionsMet()
		{
			return DependentInteractable.CurrentState == RequiredState;
		}
	}
}
