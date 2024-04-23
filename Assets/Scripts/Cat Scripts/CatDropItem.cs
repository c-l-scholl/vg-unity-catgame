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
        if (CatBagUI.uiItems[0].item != null) {
            CatBagUI.DropItem(0);
            catInventory.SetPickedUpItem(false);
        }
    }

    public void TransferToBox() {
        if (CatBagUI.uiItems[0].item != null) {
            InventoryItemData item = CatBagUI.RemoveItem(0);
            if (BoxUI != null) {
                BoxUI.AddNewItem(item);
            }

            catInventory.SetPickedUpItem(false);
        }
    }
}
