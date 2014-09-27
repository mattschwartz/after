using UnityEngine;
using System.Collections;
using After.Interactable;

public class LiftLeverController : InteractableController
{

    #region Private Members

    private bool Enabled = false;
    private Animator Animator;

    #endregion

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!Conditions.TestConditionsMet()) {
            Enabled = false;
            Animator.SetBool("Enabled", false);
        }
    }

    public override void OnInteract()
    {
        // If generator is powered on
        Enabled = !Enabled;
        Animator.SetBool("Enabled", Enabled);
    }

    public bool IsEnabled()
    {
        return Enabled;
    }
}
