using UnityEngine;
using UnityEngine.Events;

public class CatDropItem : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInventory catInventory;
    public UIInventory BoxUI;
    public UIInventory CatBagUI;
    void Start()
    {
        catInventory = GetComponent<PlayerInventory>();
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
            CatBagUI.DropItem(0);
            catInventory.SetPickedUpItem(false);
        }
    }

    public void TransferToBox() {
        if (!catInventory.inventory.IsEmpty()) {
            InventoryItemData item = CatBagUI.RemoveItem(0);
            if (BoxUI != null) {
                BoxUI.AddNewItem(item);
            }

            catInventory.SetPickedUpItem(false);
        }
    }
}
