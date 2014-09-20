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
        Debug.Log("Playing footstep sound");
        AudioManager.PlayMaterialFootstepAtPoint(StepSounds, transform.position);
    }
}
