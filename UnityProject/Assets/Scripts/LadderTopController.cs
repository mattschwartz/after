using UnityEngine;
using System.Collections;

public class LadderTopController : MonoBehaviour {

    public LadderController LadCon;

    void OnTriggerEnter2D ()
    {
        LadCon.AtTop(true);
    }

    void OnTriggerExit2D ()
    {
        LadCon.AtTop(false);
    }
}
