using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;

public class LadderPromptController : MonoBehaviour 
{
    public GameObject PromptDestroyerGameObject;
    public GameObject LadderPromptGameObject;

    void Start() 
    {
        if (!SceneHandler.OnMobile) {
            Destroy(PromptDestroyerGameObject);
            Destroy(LadderPromptGameObject);
        }
    }
}
