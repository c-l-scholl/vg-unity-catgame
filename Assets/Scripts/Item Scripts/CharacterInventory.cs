using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (other.TryGetComponent(out CollectableItem itemToPickUp))
            {
                inventory.AddItemToInventory(itemToPickUp.CollectItem());
            }
            
        }
    }
}
