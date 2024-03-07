using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ItemInstance
{
    public InventoryItemData itemType;

    public ItemInstance(InventoryItemData itemData)
    {
        this.itemType = itemData;
    }
}
