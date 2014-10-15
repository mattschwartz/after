using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "Particles";
    }
}
