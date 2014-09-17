using UnityEngine;
using System.Collections;

public class GeneratorInteractableController : InteractableController
{
    #region Public Members

    public BoxCollider2D PowerOutageTrigger;

    #endregion

    public override void Interact()
    {
        PowerOutageTrigger.GetComponent<BoxCollider2D>().enabled = true;
    }
}
