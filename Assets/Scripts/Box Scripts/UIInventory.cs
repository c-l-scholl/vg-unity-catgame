using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 3;
    public Vector2 dropLocation;

    private void Awake() {
        for (int i = 0; i < numberOfSlots; i ++) {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, InventoryItemData item) {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(InventoryItemData item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(InventoryItemData item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }

    public void RemoveFirstItem() {
        if (uiItems[0].item != null) {
            GameObject itemModel = Instantiate(uiItems[0].item.model);
            itemModel.transform.position = new Vector3(dropLocation.x, dropLocation.y, 0);
            uiItems[0].UpdateItem(null);
        }
    }
}