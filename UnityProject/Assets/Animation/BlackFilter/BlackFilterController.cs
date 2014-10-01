using UnityEngine;
using System.Collections;

public class BlackFilterController : MonoBehaviour {

    public GeneratorInteractableController GeneratorController;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Animator.SetBool("Enabled", !GeneratorController.PoweredOn);
    }
}
