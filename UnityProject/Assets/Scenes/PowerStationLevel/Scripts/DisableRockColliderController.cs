using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using After.ProximityTrigger;

public class DisableRockColliderController : MonoBehaviour
{
    #region Members

    public GameObject WatchFor;
    public Sprite CrushedTrapdoor;
    public SpriteRenderer TrapdoorSpriteRenderer;
    public ProximityTriggerController TrapdoorTriggerController;
    public Collider2D ChangeToTrigger;
    public List<Collider2D> PassThrough;

    #endregion

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != WatchFor) { return; }

        PassThrough.ForEach(t => Physics2D.IgnoreCollision(t, other));

        ChangeToTrigger.isTrigger = true;
        other.isTrigger = false;
        TrapdoorSpriteRenderer.sprite = CrushedTrapdoor;
        TrapdoorTriggerController.CurrentState = After.Interactable.StateType.Unlocked;
    }
}
