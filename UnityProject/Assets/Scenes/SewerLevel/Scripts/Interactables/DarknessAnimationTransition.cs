using After.Interactable;
using After.Interactable.Transitions;
using System.Collections;
using UnityEngine;

public class DarknessAnimationTransition : Transition
{
    public SpriteRenderer Darkness;

    public override void Read(StateType fromState, StateType toState)
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        while (Darkness.color.a > 0.1f) {
            var color = Darkness.color;
            color.a = Mathf.Lerp(color.a, 0, Time.deltaTime);
            yield return 0;
            Darkness.color = color;
        }

        Destroy(Darkness.gameObject);
    }
}
