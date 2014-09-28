using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{

    private KeyCode ContinueButton = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(ContinueButton)) {
            Application.LoadLevel("SewerLevel");
        }
    }
}
