using UnityEngine;
using System.Collections;

public class CutSceneController : MonoBehaviour 
{
	public SceneFaderController Fader;

	void Update() 
	{
		if (Input.anyKey) {
			LoadNextLevel();
		}
	}

	public void LoadNextLevel() 
	{
		StartCoroutine(Fader.FadeOut());
	}
}
