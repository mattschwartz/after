using UnityEngine;
using System.Collections;
using After.Interactable.Transitions;
using After.Interactable;

public class CameraSwapTransition : Transition
{
    public Camera SwapTo;

    void Start()
    {
        SwapTo.enabled = false;
    }

    public override void Read(StateType fromState, StateType toState)
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
        Camera.main.enabled = false;
        SwapTo.enabled = true;
        SwapTo.GetComponent<AudioListener>().enabled = true;
    }
}
