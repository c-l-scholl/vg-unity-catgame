using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryItemData item;
    public InventoryItemData CollectItem()
    {
        return item;
    }

    public void destroyItem() {
        if (this.gameObject != null){
            Debug.Log("destroying" + item);
            Destroy(this.gameObject);
        }
        
    }
}
