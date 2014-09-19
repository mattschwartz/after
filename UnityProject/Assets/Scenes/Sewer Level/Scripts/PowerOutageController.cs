using UnityEngine;
using System.Collections;

public class PowerOutageController : AudioTriggerController
{

	#region Public Members

	public GameObject Generator;

    #endregion

    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void OnEnter()
    {
    	Generator.SendMessage("SetPoweredOn", false);
    }
}
