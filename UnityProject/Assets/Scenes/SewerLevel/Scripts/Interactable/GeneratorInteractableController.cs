using UnityEngine;
using System.Collections;
using After.Interactable;

public class GeneratorInteractableController : InteractableController
{
    #region Public Members

    public AudioClip GeneratorSoundLoop;
    public BoxCollider2D PowerOutageTrigger;

    #endregion

    #region Private Members

    private bool PoweredOn = false;

    #endregion

    public override void OnInteract()
    {
    	SetPoweredOn(true);

        if (PowerOutageTrigger) {
            PowerOutageTrigger.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void DestroyAudioTrigger()
    {
        Destroy(PowerOutageTrigger.gameObject);
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
