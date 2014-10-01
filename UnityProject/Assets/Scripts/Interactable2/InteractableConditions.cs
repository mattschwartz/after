using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Interactable
{
    public abstract class InteractableConditions : MonoBehaviour
    {
        public abstract bool ConditionsMet();
    }
}
