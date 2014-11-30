using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;
using After.Scene.SceneManagement;

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

    private bool HideGUI = false;
    private float btnWidth = 194;
    private float btnHeight = 70;
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
        float scale = ((float)Screen.width / 960f);
        float x = btnWidth * scale;
        float y = btnHeight * (x / btnWidth);

        var camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.6f));
        var bounds = new Rect(camPos.x - x / 2, camPos.y - y / 2, 
            x, y);

        NewGamePosition = bounds;

        camPos = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.75f));
        bounds = new Rect(camPos.x - x / 2, camPos.y - y / 2, 
            x, y);

        ExitPosition = bounds;

        // NYI
        // ContinuePosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs, btnWidth, btnHeight);
        // OptionsPosition = new Rect(camPos.x - btnWidth / 2, camPos.y - btnWidth / 2 + yOffs * 2, btnWidth, btnHeight);
    }

    private void PlayRandomClick()
    {
        float pitch = 1 + (Notes[Random.Range(0, Notes.Count - 1)]);
        AudioManager.PlayClipAtPoint(ClickClip, pitch, transform.position, Volume);
    }

    private void NewGame_Click()
    {
        HideGUI = true;
        PlayRandomClick();
        StartCoroutine(SceneFader.FadeOut());
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
        if (HideGUI) { return; }

        DefineBounds();

        if (GUI.Button(NewGamePosition, GUIContent.none, NewGameStyle)) {
            NewGame_Click();
        }

        if (!SceneHandler.OnMobile) { return; }

        if (GUI.Button(ExitPosition, GUIContent.none, ExitStyle)) {
            Exit_Click();
        }

        // NYI
        // if (GUI.Button(ContinuePosition, GUIContent.none, ContinueStyle)) {
        //     Continue_Click();
        // }

        // if (GUI.Button(OptionsPosition, GUIContent.none, OptionsStyle)) {
        //     Options_Click();
        // }
    }
}
