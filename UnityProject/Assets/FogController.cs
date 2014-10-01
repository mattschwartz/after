using UnityEngine;
using System.Collections;

public class FogController : MonoBehaviour
{
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "Particles";
    }
}
