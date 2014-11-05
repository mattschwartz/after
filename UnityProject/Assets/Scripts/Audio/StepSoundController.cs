using UnityEngine;
using System.Collections;
using After.Audio;
using System.Collections.Generic;

public class StepSoundController : MonoBehaviour
{
    #region Public Members

	public float Volume = 1;
    public List<AudioClip> StepSounds;

    #endregion

    public void PlayFootstep()
    {
        AudioManager.PlayMaterialFootstepAtPoint(StepSounds, transform.position, Volume);
    }
}
