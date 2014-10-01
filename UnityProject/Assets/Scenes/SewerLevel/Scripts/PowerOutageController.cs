using UnityEngine;
using System.Collections;

public class PowerOutageController : AudioTriggerController
{
	#region Public Members

	public GameObject Generator;
    public GameObject LiftLever;

    #endregion

    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void OnEnter()
    {
    	Generator.SendMessage("ExpendFuel");
        LiftLever.SendMessage("Disable");
    }
}
