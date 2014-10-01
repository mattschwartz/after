using After.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class AudioTransition : Transition
    {
        public AudioClip Clip;

        public override bool Read(StateType fromState, StateType toState)
        {
            AudioManager.PlayClipAtPoint(Clip, transform.position);

            return true;
        }
    }
}
