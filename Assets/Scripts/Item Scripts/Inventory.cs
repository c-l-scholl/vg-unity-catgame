using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    private List<GameObject> items;

    public int maxItems;

    void Start()
    {
        items = new List<GameObject>();
    }

    public bool HasItemsInInventory()
    {
        return items.Count > 0;
    }

    public void AddItemToInventory(GameObject item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);;
        }
        
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

