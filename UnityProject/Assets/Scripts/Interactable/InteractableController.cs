using UnityEngine;
using System.Collections;
using After.Interactable;

public class InteractableController : MonoBehaviour
{
    #region Public Members

    public KeyCode InteractButton = KeyCode.E;
    public InteractableConditions Conditions;

    #endregion

    #region Private Members

    private bool Entered = false;

    #endregion

    void Start()
    {
    }

    #region Update

    void Update()
    {
        if (Entered &&  Input.GetKeyDown(InteractButton)) {
            if (Conditions == null || Conditions.ConditionsMet()) {
                Interact();
            }
        }
    }

    #endregion

    #region Triggers

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!InLayerMask(other)) {
            return;
        }
        
        Entered = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!InLayerMask(other)) {
            return;
        }

        Entered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer + " exited");
        Entered = false;
    }

    bool InLayerMask(Collider2D other)
    {
        return other.gameObject.layer == LayerMask.NameToLayer("Player");
    }

    #endregion

    public virtual void Interact()
    {
        // Override this function in subclasses
    }
}
