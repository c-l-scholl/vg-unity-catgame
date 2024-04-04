using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Inventory inventory;
    private bool pickedUpItem = false;

    public void OnApplicationQuit() {
        inventory.items.Clear();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && !pickedUpItem)
        {
            if (other.TryGetComponent(out CollectableItem itemToPickUp))
            {
                if (inventory.AddItemToInventory(itemToPickUp.CollectItem())) {
                    itemToPickUp.destroyItem();
                }
                pickedUpItem = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pickedUpItem = false;
    }

    public void SetPickedUpItem(bool isItemPickedUp)
    {
        pickedUpItem = isItemPickedUp;
    }
}
