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
        interactWithBox = new UnityEvent();
        endBoxInteraction = new UnityEvent();
    }

    private void Update() {
        // if (Input.GetKey(KeyCode.Escape) && interacting) {
        //     interacting = false;
        //     endBoxInteraction.Invoke();
        // }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && other.TryGetComponent(out CatMovement catMovement))
        {
            interactWithBox.Invoke();
            interacting = true;
        }

        // if (other.TryGetComponent(out CollectableItem itemToPickUp))
        // {
        //     uiInventory.AddNewItem(itemToPickUp.CollectItem());
        // }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     interacting = false;
    // }
}
