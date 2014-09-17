using UnityEngine;
using System.Collections;

public class GeneratorInteractableController : InteractableController
{
    #region Public Members

    public BoxCollider2D PowerOutageTrigger;

    #endregion

    public override void Interact()
    {
    	SetPoweredOn(true);

        if (PowerOutageTrigger != null) {
            PowerOutageTrigger.GetComponent<BoxCollider2D>().enabled = true;
            PowerOutageTrigger = null;   
        }
    }

    public void SetPoweredOn(bool on) 
    {
    	GetComponent<Animator>().SetBool("PoweredOn", on);
    }
}
