using UnityEngine;
using System.Collections;
using After.Interactable;

public class GeneratorInteractableController : InteractableController
{
    #region Public Members

    public GameObject GeneratorSoundLoop;
    public BoxCollider2D PowerOutageTrigger;

    #endregion

    #region Private Members

    private bool PoweredOn = false;

    #endregion

    public override void Interact()
    {
    	SetPoweredOn(true);

        if (PowerOutageTrigger != null) {
            PowerOutageTrigger.GetComponent<BoxCollider2D>().enabled = true;
            PowerOutageTrigger = null;   
        }
    }

    public override void ConditionsFailed()
    {
        
    }

    public bool IsPoweredOn()
    {
        return PoweredOn;
    }

    public void SetPoweredOn(bool on) 
    {
        PoweredOn = on;
    	GetComponent<Animator>().SetBool("PoweredOn", on);
    }
}
