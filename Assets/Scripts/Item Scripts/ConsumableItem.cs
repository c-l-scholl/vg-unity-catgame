using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
    // Start is called before the first frame update
    // public InventoryItemData item;
    // public InventoryItemData ConsumeItem()
    // {
    //     return item;
    // }

    public void destroyItem() {
        Destroy(this.gameObject);
    }
}
