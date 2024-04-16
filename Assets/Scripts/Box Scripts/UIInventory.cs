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
    public Inventory boxInventory;
    private int emptySlots;

    private void Awake() {
        for (int i = 0; i < numberOfSlots; i ++) {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
        emptySlots = numberOfSlots;
    }

    public void UpdateSlot(int slot, InventoryItemData item) {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(InventoryItemData item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
        boxInventory.AddItemToInventory(item);
        emptySlots--;
    }

    public void RemoveItem(InventoryItemData item) {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
        boxInventory.RemoveItemFromInventory(item);
        emptySlots++;
    }

    public void RemoveItem(int index) {
        if (uiItems[index].item != null) {

            switch(emptySlots) {
                case 2:
                    index = 0;
                    break;
                case 1:
                    if (index > 0) {
                        index = 1;
                    } else {
                        index = 0;
                    }
                    break;
                default:
                    break;
            }

            boxInventory.RemoveItem(index);
            GameObject itemModel = Instantiate(uiItems[index].item.model);
            itemModel.transform.position = new Vector3(dropLocation.x, dropLocation.y, 0);
            uiItems[index].UpdateItem(null);
        }
    }
}
