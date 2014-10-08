using After.Interactable.Transitions;
using UnityEngine;
using After.Interactable;
using After;
using System.Collections;

public class SoulsplosionTransition : Transition
{
    public Animator Animator;
    public GUITexture FlashTexture;

    void Start()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        FlashTexture.transform.position = new Vector3(0, 0);
        FlashTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        FlashTexture.enabled = false;
    }

    public override void Read(StateType fromState, StateType toState)
    {
        Animator.SetTrigger("SoulRelease");
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(1.85f);
        FlashTexture.color = new Color(1, 1, 1, 0.5f);
        FlashTexture.enabled = true;

        while (FlashTexture.color.a > 0.3f) {
            FlashTexture.color = Color.Lerp(FlashTexture.color, Color.clear, Time.deltaTime);
            yield return 0;
        }

        FlashTexture.color = Color.clear;
        FlashTexture.enabled = false;
    }
}