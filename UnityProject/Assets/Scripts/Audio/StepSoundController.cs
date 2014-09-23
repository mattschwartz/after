using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;

public class StepSoundController : MonoBehaviour
{
    #region Public Members

    public List<AudioClip> StepSounds;

    #endregion

    public void PlayFootstep(float volume=1.0F)
    {
        AudioManager.PlayMaterialFootstepAtPoint(StepSounds, transform.position, volume);
    }
}
