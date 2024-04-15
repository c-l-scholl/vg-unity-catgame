using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class CharacterInventory : MonoBehaviour
{
    public Inventory inventory;
    // public Canvas itemsBoard;
    // public GameObject eatButton;
    // public GameObject swapButton;
    // public GameObject pickUpButton;
    private bool pickedUpItem = false;
    // public UnityEvent addHealthFromFood;
    void Start()
    {
        
        // itemsBoard.enabled = false;
    }

    public void OnApplicationQuit()
    {
        inventory.items.Clear();
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (Input.GetKey(KeyCode.Space) && !pickedUpItem)
    //     {
            
    //         if (other.TryGetComponent(out ConsumableItem itemToEat))
    //         {
    //             itemToEat.destroyItem();
    //             CatSingleton.GetCatSingleton().gameObject.GetComponent<CatHealth>().AddHealthFromFood();
    //         }
    //         else if (other.TryGetComponent(out CollectableItem itemToPickUp))
    //         {
    //             if (inventory.AddItemToInventory(itemToPickUp.CollectItem()))
    //             {
    //                 itemToPickUp.destroyItem();
    //             }
    //             pickedUpItem = true;
    //         }

    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     pickedUpItem = false;
    // }

    // public void SetPickedUpItem(bool isItemPickedUp)
    // {
    //     pickedUpItem = isItemPickedUp;
    // }
}
