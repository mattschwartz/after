using UnityEngine;
using System.Collections;
using After.Audio;

public class OverlayController : MonoBehaviour
{

    #region Members

    public SpriteRenderer Blur;
    public SpriteRenderer CameraOverlay;
    public SpriteRenderer ScanLines;
    public SpriteRenderer GlitchInBackground;
    public AudioClip ToggleClip;

    private bool CameraOn = false;
    private float ToggleDelay = 8;
    private float DelayTracker = 0;

    #endregion

    void Start()
    {
        DisableSprites();
    }

    void Update()
    {
        DelayTracker += Time.deltaTime;

        if (DelayTracker >= ToggleDelay) {
            Toggle();
        }
    }

    void FixedUpdate()
    {
        if (!CameraOn) { return; }

        float ran = Random.Range(3, 9);

        if (Time.fixedTime % ran == 0) {
            StartCoroutine(Glitch());
        }
    }

    private IEnumerator Glitch()
    {
        GlitchInBackground.enabled = true;
        yield return new WaitForSeconds(0.1f);
        GlitchInBackground.enabled = false;
    }

    private void Toggle()
    {
        CameraOn = !CameraOn;

        if (CameraOn) {
            StartCoroutine(TurnCameraOn());
        } else {
            DisableSprites();
            AudioManager.PlayClipAtPoint(ToggleClip, transform.position, 0.8f, 1);
        }

        ToggleDelay = Random.Range(8, 15);
        DelayTracker = 0;
    }

    private void DisableSprites()
    {
        Blur.enabled = false;
        CameraOverlay.enabled = false;
        ScanLines.enabled = false;
        GlitchInBackground.enabled = false;
    }

    private IEnumerator TurnCameraOn()
    {
        Blur.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Blur.enabled = false;

        CameraOverlay.enabled = true;
        ScanLines.enabled = true;
        AudioManager.PlayClipAtPoint(ToggleClip, transform.position, 0.8f, 1);
    }
}
