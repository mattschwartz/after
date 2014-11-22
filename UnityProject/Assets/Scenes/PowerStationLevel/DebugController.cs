using UnityEngine;
using System.Collections;

public class DebugController : MonoBehaviour {

    public PlayerController Player;
    public ObservationsController Obs;

    void FixedUpdate()
    {
        Obs.SetThought("Position: " + Player.transform.position);
    }
}
