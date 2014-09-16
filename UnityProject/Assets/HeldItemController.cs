using UnityEngine;
using System.Collections;

public class HeldItemController : MonoBehaviour
{
    #region Public Members

    public GameObject Player;

    #endregion

    #region Private Members

    private GameObject ItemHeld;

    #endregion

    void Update()
    {
        var pos = Player.transform.position;
        transform.position = new Vector2(pos.x, pos.y + 2);
    }

    public void SetItemHeld(GameObject item)
    {
        ItemHeld = item;
    }

    public void DropItem()
    {
        if (ItemHeld == null) {
            return;
        }

        ItemHeld.transform.position = transform.position;
    }
}
