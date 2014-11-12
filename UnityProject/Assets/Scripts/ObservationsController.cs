using UnityEngine;
using System.Collections;

public class ObservationsController : MonoBehaviour
{
    public Vector3 screenPosition;
    public string Observations;
    public GUIStyle opaCustomStyle;

    private bool ShowThought = true;
    private float DisplayTime;
    private float FadeTime;

    void FixedUpdate()
    {
        DisplayTime += Time.deltaTime;

        if (DisplayTime >= FadeTime) {
            ShowThought = false;
        }
    }

    void OnGUI()
    {
        if (!ShowThought) { return; }


        opaCustomStyle.fixedWidth = Screen.width * 0.90f;
        opaCustomStyle.fontSize = (int)((float)38 * 0.90f * ((float)Screen.width / 960f));
        screenPosition = Camera.main.ViewportToScreenPoint(new Vector3(0.05f, 0.95f, 0));
        GUI.Label(new Rect(screenPosition.x, screenPosition.y, 0, 0), Observations, opaCustomStyle);
    }

    #region Message Functions

    public void SetThought(string observations)
    {
        Observations = observations;
        DisplayTime = 0;
        FadeTime = (observations.Split(' ').Length) * 0.30f;

        ShowThought = true;
    }

    #endregion
}
