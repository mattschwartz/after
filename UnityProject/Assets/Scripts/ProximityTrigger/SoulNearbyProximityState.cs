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
        public Animator PlayerSoulGlow;
        public SoulController Soul;
        public AudioSource AmbienceLoop;

        public override StateType? OnEnter(UnityEngine.Collider2D other)
        {
            if (Soul.Freed) {
                return To;
            }

            PlayerSoulGlow.SetBool("Glowing", true);
            AmbienceLoop.Play();
            return null;
        }

        public override StateType? OnRemain(Collider2D other)
        {
            if (Soul.Freed) {
                PlayerSoulGlow.SetBool("Glowing", false);
                AmbienceLoop.Stop();
                return To;
            }

            var distance = Vector2.Distance(transform.position, PlayerSoulGlow.transform.position);
            var opacity = Mathf.Clamp(1 - (distance / 8.33f) + 0.17f, 0, 1);
            var cl = PlayerSoulGlow.renderer.material.color;
            cl.a = opacity;
            PlayerSoulGlow.renderer.material.color = cl;

            AmbienceLoop.volume = opacity;

            return null;
        }

        public override StateType? OnExit(Collider2D other)
        {
            PlayerSoulGlow.SetBool("Glowing", false);
            StartCoroutine(AudioManager.FadeMusic(AmbienceLoop));
            return null;
        }
    }
}
