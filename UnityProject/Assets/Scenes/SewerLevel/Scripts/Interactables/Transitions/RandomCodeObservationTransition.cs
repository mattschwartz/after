using After.Interactable;
using After.Interactable.Transitions;
using UnityEngine;
using System.Collections;

public class RandomCodeObservationTransition : Transition
{
    public ObservationsController Observations;

    private int TriedNumbers = 0;

    public override void Read(StateType fromState, StateType toState)
    {
        string observations = "A numeric code. How about ";

        if (TriedNumbers < 1000) {
            observations += "0";
        }
        if (TriedNumbers < 100) {
            observations += "0";
        }
        if (TriedNumbers < 10) {
            observations += "0";
        }

        observations += TriedNumbers + "... Nope.";

        if (TriedNumbers > 9999) {
            observations = "Did I miss a number?";
            TriedNumbers = -1;
        }

        Observations.SetThought(observations);

        do {
            ++TriedNumbers;
        } while (TriedNumbers == 4239);
    }
}
