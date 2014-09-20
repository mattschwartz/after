using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;

public class StepSoundController : MonoBehaviour
{
    #region Public Members

    public List<AudioClip> StepSounds;

    #endregion

    public void PlayFootstep()
    {
        AudioManager.PlayMaterialFootstepAtPoint(StepSounds, transform.position);
    }
}
