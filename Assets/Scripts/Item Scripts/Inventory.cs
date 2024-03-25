using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItemData> items = new List<InventoryItemData>();
    public int maxItems;

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
        Debug.Log("No inventory slots open");
        return false;

    }

    public void DropItem(int itemIndex)
    {
        // Creates a new object and gives it the item data
        // GameObject droppedItem = new GameObject();
        // droppedItem.AddComponent<Rigidbody>();
        // droppedItem.AddComponent<InstanceItemContainer>().item = inventory.items[itemIndex];
        // GameObject itemModel = Instantiate(inventory.items[itemIndex].itemType.model, droppedItem.transform);

        // // Removes the item from the inventory
        // inventory.items.RemoveAt(itemIndex);

        // // Updates the inventory again
        // UpdateInventory();
    }

    public bool RemoveItemFromInventory(InventoryItemData itemToRemove)
    {
        return items.Remove(itemToRemove);
    }
}