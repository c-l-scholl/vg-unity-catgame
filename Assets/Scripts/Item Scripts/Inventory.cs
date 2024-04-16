using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    // treat as private
    
    public List<InventoryItemData> items;
    public int maxItems;
    
    public bool AddItemToInventory(InventoryItemData itemToAdd)
    {
        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }
        return false;
    }

    public void DropItem(int itemIndex)
    {
        // Creates a new object and gives it the item data
        if (itemIndex < 0 || itemIndex >= items.Count)
        {
            return;
        }
        GameObject itemModel = Instantiate(items[itemIndex].model);
        itemModel.transform.position = CatSingleton.GetCatSingleton().transform.position;
        CatSingleton.GetCatSingleton().GetComponent<PlayerInventory>().SetPickedUpItem(false);

        // Removes the item from the inventory
        items.RemoveAt(itemIndex);
    }

    public bool HasItem(InventoryItemData item)
    {
        return items.Contains(item);
    }

    public bool RemoveItemFromInventory(InventoryItemData itemToRemove)
    {
        return items.Remove(itemToRemove);
    }

    public InventoryItemData RemoveItemFromInventory(int itemIndex) {
        
        InventoryItemData item = items[itemIndex];
        items.RemoveAt(itemIndex);
        return item;
    }

    public bool MoveItemToOtherInventory(InventoryItemData item, Inventory other)
    {
        if (HasItem(item))
        {
            RemoveItemFromInventory(item);
            other.AddItemToInventory(item);
            return true;
        }
        else 
        {
            return false;
        }
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void RemoveItem(int index)
    {
        items.RemoveAt(index);
    }

    public void AddQuestItem(InventoryItemData questItem)
    {
        items.Add(questItem);
    }

    public void ClearItems()
    {
        items.Clear();
    }

    // public void TransferItem() {
    //     if (items.Count > 0) {
    //         DropItem(0);
    //     }
    // }
}