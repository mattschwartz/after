using UnityEngine;
using System.Collections;

public class BendBarsController : MonoBehaviour {

    private Vector2 BentBarsPosition;

    void Start()
    {
        BentBarsPosition = new Vector2(0.2757445f, 4.329851f);
        transform.position = new Vector2(-5000, 5000);
    }

    public void BendBars()
    {
        transform.position = BentBarsPosition;
    }
}
