using System;
using UnityEngine;
using UnityEngine.Events;

public class BoxInteraction : MonoBehaviour
{
    private bool interacting;
    public UIInventory inventoryPanel;
    public UnityEvent interactWithBox;
    public UnityEvent endBoxInteraction;

    void Start()
    {
        interacting = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && interacting)
        {
            interacting = false;
            endBoxInteraction.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.TryGetComponent(out CollectableItem itemToPickUp) && interacting)
        {
            itemToPickUp.destroyItem();
            inventoryPanel.AddNewItem(itemToPickUp.CollectItem());
        }

        if (other.TryGetComponent(out CatSingleton cat) && Input.GetKey(KeyCode.Space) && !interacting)
        {
            Debug.Log("Interacting with inventory somehow");
            interactWithBox.Invoke();
            interacting = true;
        }


    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     interacting = false;
    // }
}
