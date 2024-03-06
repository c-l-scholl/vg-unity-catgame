using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    // set items to private later, only keeping it here for debugging
    public List<GameObject> items;

    public int maxItems;

    void Start()
    {
        items = new List<GameObject>();
    }

    public bool IsInventoryEmpty()
    {
        return items.Count == 0;
    }

    // could change this to boolean to help with GUI decision making
    public bool AddItemToInventory(GameObject item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            return true;
        }
        return false;
        
    }

    public GameObject RemoveItemFromInventory(GameObject item) 
    {
        if (items.Remove(item))
        {
            return item;
        }
        else
        {
            return null;
        }
    }
}

