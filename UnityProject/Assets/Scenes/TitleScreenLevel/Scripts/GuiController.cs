using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;

public class GuiController : MonoBehaviour
{

    #region Members

    public float Volume = 1;
    public GUIStyle NewGameStyle;
    public GUIStyle ContinueStyle;
    public GUIStyle OptionsStyle;
    public GUIStyle ExitStyle;
    public SceneFaderController SceneFader;
    public AudioClip ClickClip;

    private float btnWidth = 123;
    private float btnHeight = 20;
    private float yOffs = 30;
    private Rect NewGamePosition;
    private Rect ContinuePosition;
    private Rect OptionsPosition;
    private Rect ExitPosition;
    private List<float> Notes;

    #endregion

    void Start() 
    {
        Notes = new List<float>() {
            0.05946309435905f,
            0.12246204830885f,
            0.1892071150019f,
            0.2599210498937f,
            0.3348398541685f,
            0.4142135623711f,

            -0.05946309435905f,
            -0.12246204830885f,
            -0.1892071150019f,
            -0.2599210498937f,
            -0.3348398541685f,
            -0.4142135623711f
        };
    }

    private void DefineBounds()
    {
        var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.65f));

        NewGamePosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2, btnWidth, btnHeight);
        ContinuePosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs, btnWidth, btnHeight);
        OptionsPosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs * 2, btnWidth, btnHeight);
        ExitPosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs * 3, btnWidth, btnHeight);
    }

    private void PlayRandomClick()
    {
        float pitch = 1 + (Notes[Random.Range(0, Notes.Count - 1)]);
        AudioManager.PlayClipAtPoint(ClickClip, pitch, transform.position, Volume);
    }

    private void NewGame_Click()
    {
        PlayRandomClick();
    }

    private void Continue_Click()
    {
        PlayRandomClick();
    }

    private void Options_Click()
    {
        PlayRandomClick();
    }

    private void Exit_Click()
    {
        PlayRandomClick();
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
