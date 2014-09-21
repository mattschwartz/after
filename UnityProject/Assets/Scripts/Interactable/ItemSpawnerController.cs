using UnityEngine;
using System.Collections;
using After.Interactable;

public class ItemSpawnerController : InteractableController
{
    #region Public Members

    public GameObject ItemToSpawn; // Should be a Grabbable prefab

    #endregion

    void Start()
    {
        ItemToSpawn.GetComponent<SpriteRenderer>().enabled = false;
        ItemToSpawn.transform.position = new Vector2(5000, 5000);
    }

    public sealed override void Interact()
    {
        if (ItemToSpawn == null) {
            return;
        }

        ItemToSpawn.GetComponent<SpriteRenderer>().enabled = true;
        ItemToSpawn.transform.position = transform.position;
        ItemToSpawn.rigidbody2D.velocity = Vector2.zero;
        ItemToSpawn.rigidbody2D.AddForce(Vector2.up * 1000f);
        ItemToSpawn = null;

        OnInteract();
    }

    public virtual void OnInteract()
    {
        // Override this method in subclasses
    }
}
