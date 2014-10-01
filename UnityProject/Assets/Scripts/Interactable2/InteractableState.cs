﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Interactable
{
    public class InteractableState : MonoBehaviour
    {
        public StateType To;
        public InteractableConditions Conditions;

        public StateType? Transition()
        {
            if (Conditions == null || Conditions.ConditionsMet()) {
                return To;
            }

            return null;
        }
    }
}
