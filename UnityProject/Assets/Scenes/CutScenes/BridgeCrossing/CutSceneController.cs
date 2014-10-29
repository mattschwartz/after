using UnityEngine;
using System.Collections;

public class CutSceneController : MonoBehaviour 
{
	public SceneFaderController Fader;
    public float Duration;
    private float Tick;

	void Update() 
	{
        Tick += Time.deltaTime;
		if (Input.anyKey || Tick >= Duration) {
            //NYI: stop and ding
			LoadNextLevel();
		}
	}

	public void LoadNextLevel() 
	{
		StartCoroutine(Fader.FadeOut());
	}
}
