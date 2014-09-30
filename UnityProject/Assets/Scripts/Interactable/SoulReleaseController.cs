using After.Interactable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Interactable
{
    public class SoulReleaseController : InteractableController
    {
        #region Public Members

        public GameObject ItemToSpawn;
        public InteractableConditions Conditions;

        #endregion

        #region Private Members
        #endregion

        public override void Interact()
        {
            if (Conditions || Conditions.ConditionsMet()) {
                OnInteract();
            }
        }

        public virtual void OnInteract()
        {

        }

        public virtual void ConditionsFailed()
        {

        }
    }
}
