using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;
using System.Collections;

public class RandomCodeObservationTransition : Transition
{
    private GameObject PlayerThoughts;

    void Start()
    {
        PlayerThoughts = GameObject.Find("Player Thoughts");
    }

    public override void Read(StateType fromState, StateType toState)
    {
        int tryCode;
        string observations = "A numeric code, hmm... ";

        do {
            tryCode = Random.Range(1000, 9999);
        } while (tryCode == 4239);

        observations += tryCode + "... Nope.";
        PlayerThoughts.SendMessage("SetThought", observations);
    }
}
