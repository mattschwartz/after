using UnityEngine;
using System.Collections;
using After.Interactable;

public class GeneratorInteractableController : InteractableController
{
    #region Public Members

    public BoxCollider2D PowerOutageTrigger;

    #endregion

    #region Private Members

    private bool PoweredOn = false;

    #endregion

    public override void Interact()
    {
    	SetPoweredOn(true);

        if (PlayOnSuccess) {
            AudioSource.PlayClipAtPoint(PlayOnSuccess, gameObject.transform.position);
        }

        if (PowerOutageTrigger != null) {
            PowerOutageTrigger.GetComponent<BoxCollider2D>().enabled = true;
            PowerOutageTrigger = null;   
        }
    }

    public override void ConditionsFailed()
    {
        if (!PoweredOn && PlayOnFailure) {
            AudioSource.PlayClipAtPoint(PlayOnFailure, gameObject.transform.position);
        }
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
