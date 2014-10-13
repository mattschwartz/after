using UnityEngine;
using System.Collections;

public class ThoughtController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 screenPosition;
    public string Thought;
    public GUIStyle opaCustomStyle;

    private bool ShowThought = true;
    private float DisplayTime;
    private float FadeTime;

    void Update()
    {
        screenPosition = Camera.main.WorldToScreenPoint(Player.transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
    }

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

        GUI.Label(new Rect(screenPosition.x, screenPosition.y, 0, 0), Thought, opaCustomStyle);
    }

    #region Message Functions

    public void SetThought(string thought)
    {
        Thought = thought;
        DisplayTime = 0;
        FadeTime = (Thought.Split(' ').Length) * 0.30f;

        ShowThought = true;
    }

    #endregion
}
