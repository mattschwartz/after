using UnityEngine;
using System.Collections;

public class DirectiveController : MonoBehaviour
{

    #region Public Members

    public string DirectiveText;
    public GUIText Label;

    #endregion

    #region Private Members

    private bool DisplayGUI = false;
    private int DrawnCharacters = 0;

    #endregion

    void FixedUpdate()
    {
        if (!DisplayGUI) {
            return;
        }

        DrawnCharacters = Mathf.Min(DrawnCharacters + 1, DirectiveText.Length);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DisplayGUI = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Label.text = DirectiveText.Substring(0, DrawnCharacters);
        DisplayGUI = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Label.text = "";
        DisplayGUI = false;
        DrawnCharacters = 0;
    }
}
