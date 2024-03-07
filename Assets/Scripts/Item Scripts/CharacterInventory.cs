using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectableItem item))
        {
            inventory.AddItemToInventory(item.CollectItem());
        }
    }
}
