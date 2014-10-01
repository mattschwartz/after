using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour
{
    public GeneratorInteractableController GeneratorController;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Animator.SetBool("PoweredOn", GeneratorController.PoweredOn);
    }
}
