using UnityEngine;
using System.Collections;
using After.Scene.SceneManagement;

public class CreditLevelController : MonoBehaviour
{
    public GameObject ReturnPromptOther;
    public GameObject ReturnPromptMobile;

    // Use this for initialization
    void Start()
    {
        var gObject = GameObject.Find("Journal");

        if (gObject) {
            Destroy(gObject);
        }

        gObject = GameObject.Find("Backpack");

        if (gObject) {
            Destroy(gObject);
        }

        gObject = GameObject.Find("OptionsMenu");

        if (gObject) {
            Destroy(gObject);
        }

        if (SceneHandler.OnMobile) {
            Destroy(ReturnPromptOther);
        } else {
            Destroy(ReturnPromptMobile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel("TitleScreenLevel");
        }
    }
}
