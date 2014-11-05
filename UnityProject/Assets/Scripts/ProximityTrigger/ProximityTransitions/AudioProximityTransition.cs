using After.Audio;
using After.Interactable;
using UnityEngine;

namespace After.ProximityTrigger.ProximityTransitions
{
    public class AudioProximityTransition : ProximityTransition
    {

        public float Volume = 1;
        public AudioClip Clip;

        public override void Read(StateType fromState, StateType toState)
        {
            AudioManager.PlayClipAtPoint(Clip, transform.position, Volume);
        }
    }
}
