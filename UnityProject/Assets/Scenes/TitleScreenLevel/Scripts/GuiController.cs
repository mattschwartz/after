using UnityEngine;
using System.Collections;
using After.Audio;

public class GuiController : MonoBehaviour
{

    #region Members

    public GUIStyle NewGameStyle;
    public GUIStyle ContinueStyle;
    public GUIStyle OptionsStyle;
    public GUIStyle ExitStyle;
    public AudioClip MousePressClip;
    public SceneFaderController SceneFader;

    private float btnWidth = 123;
    private float btnHeight = 20;
    private float yOffs = 30;
    private Rect NewGamePosition;
    private Rect ContinuePosition;
    private Rect OptionsPosition;
    private Rect ExitPosition;

    #endregion

    private void DefineBounds()
    {
        var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.65f));

        NewGamePosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2, btnWidth, btnHeight);
        ContinuePosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs, btnWidth, btnHeight);
        OptionsPosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs * 2, btnWidth, btnHeight);
        ExitPosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs * 3, btnWidth, btnHeight);
    }

    private void NewGame_Click()
    {
        AudioManager.PlayClipAtPoint(MousePressClip, transform.position);
        StartCoroutine(SceneFader.FadeOut());
    }

    private void Continue_Click()
    {
        AudioManager.PlayClipAtPoint(MousePressClip, transform.position);
    }

    private void Options_Click()
    {
        AudioManager.PlayClipAtPoint(MousePressClip, transform.position);
    }

    private void Exit_Click()
    {
        AudioManager.PlayClipAtPoint(MousePressClip, transform.position);
        Application.Quit();
    }

    void OnGUI()
    {
        RenderButtons();
    }

    private void RenderButtons()
    {
        DefineBounds();

        if (GUI.Button(NewGamePosition, GUIContent.none, NewGameStyle)) {
            NewGame_Click();
        }

        if (GUI.Button(ContinuePosition, GUIContent.none, ContinueStyle)) {
            Continue_Click();
        }

        if (GUI.Button(OptionsPosition, GUIContent.none, OptionsStyle)) {
            Options_Click();

        }

        if (GUI.Button(ExitPosition, GUIContent.none, ExitStyle)) {
            Exit_Click();

        }
    }
}
