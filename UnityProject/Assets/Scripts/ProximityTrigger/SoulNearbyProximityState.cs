using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using UnityEngine;
using After.Audio;

namespace After.ProximityTrigger
{
    public class SoulNearbyProximityState : ProximityState
    {
        public float MaxVolume = 1;
        public GameObject Player;
        public InteractableController SoulController;
        public AudioSource AmbienceLoop;
        public Collider2D SelfCollider;

        private float MaxDistance;

        void Start()
        {
            Vector3 center = SelfCollider.bounds.center;
            Vector3 max = SelfCollider.bounds.max;

            MaxDistance = Math.Abs(Vector3.Distance(center, max));
        }

        public override StateType? OnEnter(UnityEngine.Collider2D other)
        {
            if (SoulController.CurrentState == StateType.Unlocked) {
                return To;
            }

            AmbienceLoop.Play();
            return null;
        }

        public override StateType? OnRemain(Collider2D other)
        {
            if (SoulController.CurrentState == StateType.Unlocked) {
                AmbienceLoop.Stop();
                return To;
            }

            float distance = Vector2.Distance(transform.position, Player.transform.position);
            float volume = (float)(1 - Math.Log(distance, MaxDistance));

            AmbienceLoop.volume = Mathf.Clamp(volume, 0, MaxVolume);

            return null;
        }

        public override StateType? OnExit(Collider2D other)
        {
            StartCoroutine(AudioManager.FadeMusic(AmbienceLoop));
            return null;
        }
    }
}
