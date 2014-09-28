using UnityEngine;
using System.Collections;

public class ShelvesItemSpawnerController : ItemSpawnerController
{
    private Animator Animator;

    void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        Animator.SetBool("StealGasCan", true);
    }
}
