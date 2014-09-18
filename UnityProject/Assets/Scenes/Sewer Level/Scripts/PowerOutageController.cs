using UnityEngine;
using System.Collections;

public class PowerOutageController : MonoBehaviour
{

	#region Public Members

	public GameObject Generator;

    #endregion

    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
    	Generator.SendMessage("SetPoweredOn", false);
        Destroy(gameObject);
    }
}
