using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Inventory inventory;
    private bool pickedUpItem = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && !pickedUpItem)
        {
            if (other.TryGetComponent(out CollectableItem itemToPickUp))
            {
                inventory.AddItemToInventory(itemToPickUp.CollectItem());
                pickedUpItem = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectableItem itemToPickUp))
            {
                pickedUpItem = false;
            }
    }
}
