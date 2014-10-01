using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace After.Interactable.Transitions
{
    public class ItemSpawnTransition : Transition
    {
        // Should be a Grabbable prefab
        public GameObject ItemToSpawn;

        void Start()
        {
            ItemToSpawn.GetComponent<SpriteRenderer>().enabled = false;
            ItemToSpawn.transform.position = new Vector2(5000, 5000);
        }

        public override void Read(StateType fromState, StateType toState)
        {
            ItemToSpawn.GetComponent<SpriteRenderer>().enabled = true;
            ItemToSpawn.transform.position = transform.position;
            ItemToSpawn.rigidbody2D.velocity = Vector2.zero;
            ItemToSpawn.rigidbody2D.AddForce(Vector2.up * 1000f);
            ItemToSpawn = null;
        }
    }
}
