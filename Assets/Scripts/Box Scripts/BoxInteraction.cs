using System;
using UnityEngine;
using UnityEngine.Events;

public class BoxInteraction : MonoBehaviour
{
    private bool interacting;
    public UIInventory uiInventory;
    public UnityEvent interactWithBox;
    public UnityEvent endBoxInteraction;

    void Start()
    {
        interacting = false;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape) && interacting) {
            interacting = false;
            endBoxInteraction.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.TryGetComponent(out CollectableItem itemToPickUp))
        {
            uiInventory.AddNewItem(itemToPickUp.CollectItem());
        }

        if (Input.GetKey(KeyCode.Space) && !interacting)
        {
            interactWithBox.Invoke();
            interacting = true;
        }

        
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     interacting = false;
    // }
}
