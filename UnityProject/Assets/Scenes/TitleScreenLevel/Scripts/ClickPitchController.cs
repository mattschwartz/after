using UnityEngine;
using System.Collections;

public class RClickPitchController : MonoBehaviour {

// values of notes (added to root pitch, 1)
//a = 0.05946309435905
//b = 0.12246204830885
//c = 0.1892071150019
//d = 0.2599210498937
//e = 0.3348398541685
//f = 0.4142135623711

// randomly select pitch to add to root pitch (1)
// +/- a-f
// pitch = 1 + Random([a,b,c,d,e,f, a.neg,b.neg,c.neg,d.neg,e.neg,f.neg])

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
