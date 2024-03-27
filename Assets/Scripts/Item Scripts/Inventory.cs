using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItemData> items = new List<InventoryItemData>();
    public int maxItems;

    // public bool TransferItem() {

    // }

    public bool AddItemToInventory(InventoryItemData itemToAdd)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }

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
        GameObject itemModel = Instantiate(items[itemIndex].model);
        itemModel.transform.position = CatSingleton.GetCatSingleton().transform.position;

        // Removes the item from the inventory
        items.RemoveAt(itemIndex);

        // Updates the inventory again in UI
        // UpdateInventory();
    }

    public bool RemoveItemFromInventory(InventoryItemData itemToRemove)
    {
        return items.Remove(itemToRemove);
    }

    // public void 
}