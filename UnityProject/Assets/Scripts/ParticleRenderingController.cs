using UnityEngine;
using System.Collections;

public class ParticleRenderingController : MonoBehaviour 
{
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "Particles";
    }
}
