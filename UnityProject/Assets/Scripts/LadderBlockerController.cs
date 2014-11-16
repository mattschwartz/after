using UnityEngine;
using System.Collections;

public class LadderBlockerController : MonoBehaviour {

    public LadderController LadCon;

    void OnTriggerEnter2D()
    {
        LadCon.Blocked = true;
    }

    void OnTriggerExit2D()
    {
        LadCon.Blocked = false;
    }
}
