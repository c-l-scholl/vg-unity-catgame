using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryItemData item;

    public InventoryItemData CollectItem()
    {
        Destroy(this.gameObject);
        return item;
    }
}
