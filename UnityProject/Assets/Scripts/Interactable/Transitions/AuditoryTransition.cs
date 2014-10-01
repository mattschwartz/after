using After.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class AuditoryTransition : Transition
    {
        public AudioClip Clip;

        public override void Read(StateType currentState)
        {
            AudioManager.PlayClipAtPoint(Clip, transform.position);
        }
    }
}
