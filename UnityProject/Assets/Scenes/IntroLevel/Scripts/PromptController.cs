using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;

public class PromptController : MonoBehaviour 
{
    public GameObject MovementPromptOtherGameObject;
    public GameObject InteractPromptOtherGameObject;
    public GameObject InteractPromptOtherGameObject2;

    public GameObject MovementPromptMobileGameObject;
    public GameObject InteractPromptMobileGameObject;
    public GameObject InteractPromptMobileGameObject2;
    public GameObject JumpPromptGameMobileObject;

    void Start() 
    {
        if (!SceneHandler.OnMobile) {
            MobileStart();
        } else {
            OtherStart();
        }
    }

    private void MobileStart()
    {
        Destroy(MovementPromptOtherGameObject);
        Destroy(InteractPromptOtherGameObject);
        Destroy(InteractPromptOtherGameObject2);
    }

    private void OtherStart()
    {
        Destroy(MovementPromptMobileGameObject);
        Destroy(InteractPromptMobileGameObject);
        Destroy(InteractPromptMobileGameObject2);
        Destroy(JumpPromptGameMobileObject);
    }
}
