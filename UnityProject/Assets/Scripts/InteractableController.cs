using UnityEngine;
using System.Collections;
using After;

public class InteractableController : MonoBehaviour
{
    #region Public Members

    public KeyCode InteractButton = KeyCode.E;
    public InteractableConditions Conditions;
    public struct InteractableArgs
    {
        // not sure what might be good to put in here
    }

    #endregion

    #region Private Members

    private bool Entered = false;

    #endregion

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

    void OnTriggerStay2D(Collider2D other)
    {
        Entered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entered = false;
    }

    #endregion

    public virtual void Interact()
    {
        // Override this function in subclasses
    }
}
