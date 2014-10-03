using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using After.Interactable;
using UnityEngine;

namespace After.ProximityTrigger
{
    public class SoulNearbyProximityState : ProximityState
    {
        public Animator PlayerSoulGlow;
        public GameObject AmbienceLoop;
        public SoulController Soul;

        public override StateType? OnEnter(UnityEngine.Collider2D other)
        {
            if (Soul.Freed) {
                return To;
            }

            PlayerSoulGlow.SetBool("Glowing", true);
            AmbienceLoop.GetComponent<AudioSource>().Play();
            return null;
        }

        public override StateType? OnRemain(Collider2D other)
        {
            if (Soul.Freed) {
                PlayerSoulGlow.SetBool("Glowing", false);
                AmbienceLoop.GetComponent<AudioSource>().Stop();
                return To;
            }

            var distance = Vector2.Distance(transform.position, PlayerSoulGlow.transform.position);
            var opacity = Mathf.Clamp(1 - (distance / 8.33f) + 0.17f, 0, 1);
            var cl = PlayerSoulGlow.renderer.material.color;
            cl.a = opacity;
            PlayerSoulGlow.renderer.material.color = cl;

            AmbienceLoop.GetComponent<AudioSource>().volume = opacity;

            return null;
        }

        public override StateType? OnExit(Collider2D other)
        {
            PlayerSoulGlow.SetBool("Glowing", false);
            AmbienceLoop.GetComponent<AudioSource>().Stop();
            return null;
        }
    }
}
