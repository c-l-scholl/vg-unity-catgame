using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInventory : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField]
    private Canvas itemCanvas;
    [SerializeField]
    private GameObject eatOption;
    // private Button eatButton;
    private bool pickedUpItem = false;
    // public UnityEvent addHealthFromFood;
    void Start()
    {
        
    }

    public void OnApplicationQuit()
    {
        inventory.items.Clear();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && !pickedUpItem)
        {
            
            // if Consumable: eat button enabled
            // if Collectable: 
            //      if inventory has open space: 
            //          pickup button enabled
            //          swap disabled
            //      else if inventory full:
            //          swap button enabled
            //          pickup disabled
            if (other.TryGetComponent(out ConsumableItem itemToEat))
            {
                itemToEat.destroyItem();
                CatSingleton.GetCatSingleton().gameObject.GetComponent<CatHealth>().AddHealthFromFood();
            }
            else if (other.TryGetComponent(out CollectableItem itemToPickUp))
            {
                if (inventory.AddItemToInventory(itemToPickUp.CollectItem()))
                {
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
