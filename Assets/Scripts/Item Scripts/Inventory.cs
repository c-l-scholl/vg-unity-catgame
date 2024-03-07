using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItemData> items = new();
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

    public bool RemoveItemFromInventory(InventoryItemData itemToRemove)
    {
        return items.Remove(itemToRemove);
    }
}



// public class Inventory : MonoBehaviour
// {
//     // set items to private later, only keeping it here for debugging
//     public List<GameObject> items;

//     public int maxItems;

//     void Start()
//     {
//         items = new List<GameObject>();
//     }

//     public bool IsInventoryEmpty()
//     {
//         return items.Count == 0;
//     }

//     // could change this to boolean to help with GUI decision making
//     public bool AddItemToInventory(GameObject item)
//     {
//         if (items.Count < maxItems)
//         {
//             items.Add(item);
//             return true;
//         }
//         return false;
        
//     }

//     public GameObject RemoveItemFromInventory(GameObject item) 
//     {
//         if (items.Remove(item))
//         {
//             return item;
//         }
//         else
//         {
//             return null;
//         }
//     }
// }

