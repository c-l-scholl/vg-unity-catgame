using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDropItem : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInventory catInventory;
    public UIInventory BoxUI;
    void Start()
    {
        catInventory = GetComponent<PlayerInventory>();
        // uiInventory = GetComponent<UIInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X)) 
        {
            TransferItem();
        }
    }

    public void TransferItem() {
        if (!catInventory.inventory.IsEmpty()) {
            catInventory.inventory.DropItem(0);
            catInventory.SetPickedUpItem(false);
        }
    }

    public void TransferToBox() {
        if (!catInventory.inventory.IsEmpty()) {
            InventoryItemData item = catInventory.inventory.RemoveItemFromInventory(0);
            if (BoxUI != null) {
                BoxUI.AddNewItem(item);
            }

            catInventory.SetPickedUpItem(false);
        }
    }
}
