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
    private LayerMask IncludeLayers;

    #endregion

    void Start()
    {
        IncludeLayers = LayerMask.NameToLayer("Player");
    }

    void FixedUpdate()
    {
        if (!DisplayGUI) {
            return;
        }

        DrawnCharacters = Mathf.Min(DrawnCharacters + 1, DirectiveText.Length);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!InLayerMask(other)) {
            return;
        }

        DisplayGUI = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!InLayerMask(other)) {
            return;
        }

        Label.text = DirectiveText.Substring(0, DrawnCharacters);
        DisplayGUI = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Label.text = "";
        DisplayGUI = false;
        DrawnCharacters = 0;
    }

    bool InLayerMask(Collider2D other)
    {
        return other.gameObject.layer == IncludeLayers;
    }
}
