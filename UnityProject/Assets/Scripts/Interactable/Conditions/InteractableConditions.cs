using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Conditions
{
    public class InteractableConditions : MonoBehaviour
    {
        public virtual bool ConditionsMet()
        {
            return true;
        }
    }
}
