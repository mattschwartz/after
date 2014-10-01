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
    	public float Volume = 1.0f;
        public AudioClip Clip;

        public override bool Read(StateType fromState, StateType toState)
        {
            AudioManager.PlayClipAtPoint(Clip, 1.0f, transform.position, Volume);

            return true;
        }
    }
}
