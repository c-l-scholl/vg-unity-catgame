using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots;
    public GameObject dropLocationAnchor;
    public Inventory inventory;
    private int emptySlots;
    private Vector2 dropLocation;

    private void Awake()
    {
        ResetInventory();
    }

    public void ResetInventory()
    {
        uiItems.Clear();
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
        emptySlots = numberOfSlots;
    }

    public void UpdateSlot(int slot, InventoryItemData item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public bool AddNewItem(InventoryItemData item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
        bool result = inventory.AddItemToInventory(item);
        if (!result)
        {
            Debug.Log("Add item failed");
        }
        emptySlots--;
        return result;
    }

    public void RemoveItem(InventoryItemData item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
        inventory.RemoveItemFromInventory(item);
        emptySlots++;
    }

    public void DropItem(int index)
    {
        if (uiItems[index].item != null)
        {

            if (numberOfSlots == 3)
            {
                dropLocation = new Vector2(dropLocationAnchor.transform.position.x, dropLocationAnchor.transform.position.y - 2);
            }
            else
            {
                dropLocation = new Vector2(dropLocationAnchor.transform.position.x, dropLocationAnchor.transform.position.y);
            }

            inventory.RemoveItemFromInventory(uiItems[index].item);
            GameObject itemModel = Instantiate(uiItems[index].item.model);
            itemModel.transform.position = new Vector3(dropLocation.x, dropLocation.y, 0);
            uiItems[index].UpdateItem(null);
            emptySlots++;
        }
    }

    public InventoryItemData RemoveItemReturn(int index)
    {
        if (uiItems[index].item != null)
        {

            InventoryItemData item = uiItems[index].item;
            inventory.RemoveItem(index);
            uiItems[index].UpdateItem(null);
            emptySlots++;
            return item;
        }
        return null;
    }

    public void RemoveItem(int index)
    {
        if (uiItems.Count > 0)
        {
            if (uiItems[index].item != null)
            {

                inventory.RemoveItem(index);
                uiItems[index].UpdateItem(null);
                emptySlots++;
            }
        }
    }
}
