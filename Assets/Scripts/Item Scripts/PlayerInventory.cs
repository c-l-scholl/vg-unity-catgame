using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public UIInventory catBagUI;

    public Canvas itemsBoard;

    public GameObject eatButton;

    public GameObject swapButton;

    public GameObject pickUpButton;

    private ConsumableItem foodItem;

    private CollectableItem normalItem;

    private bool pickedUpItem = false;

    private bool ableToPickUp = false;

    // public UnityEvent addHealthFromFood;
    void Start()
    {
        // itemsBoard.gameObject.SetActive(false);
    }

    void Update()
    {
        if (itemsBoard.gameObject.activeSelf || itemsBoard.enabled == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                GetComponent<CatMovement>().enableMovement();
                itemsBoard.enabled = false;
            }
        }
    }

    public void OnApplicationQuit()
    {
        ClearInventory();
    }

    public void ClearInventory() {
        inventory.items.Clear();
        catBagUI.ResetInventory();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out ConsumableItem itemToEat))
        {
            eatButton.GetComponent<Button>().interactable = true;
            foodItem = itemToEat;
            ableToPickUp = true;
        }
        else
        {
            eatButton.GetComponent<Button>().interactable = false;
        }

        if (other.TryGetComponent(out CollectableItem itemToPickUp))
        {
            normalItem = itemToPickUp;
            ableToPickUp = true;
            if (inventory.IsEmpty())
            {
                pickUpButton.GetComponent<Button>().interactable = true;
                swapButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                pickUpButton.GetComponent<Button>().interactable = false;
                swapButton.GetComponent<Button>().interactable = true;
            }
        }

        if (Input.GetKey(KeyCode.Space) && !pickedUpItem && ableToPickUp)
        {
            GetComponent<CatMovement>().disableMovement();

            if (itemsBoard.gameObject.activeSelf == false) {
                itemsBoard.gameObject.SetActive(true);
            } else {
                itemsBoard.enabled = true;
            }
        }
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (Input.GetKey(KeyCode.Space) && !pickedUpItem && ableToPickUp)
    //     {
    //         GetComponent<CatMovement>().disableMovement();
    //         itemsBoard.enabled = true;
    //     }
    // }

    public void OnOptionClicked(int selection)
    {
        switch (selection)
        {
            case 0: // eat
                foodItem.destroyItem();
                GetComponent<CatHealth>().AddHealthFromFood();
                break;
            case 1: // swap
                catBagUI.DropItem(0);
                if (catBagUI.AddNewItem(normalItem.CollectItem()))
                {
                    normalItem.destroyItem();
                }
                break;
            case 2: // pick up
                if (catBagUI.AddNewItem(normalItem.CollectItem()))
                {
                    normalItem.destroyItem();
                }
                break;
        }
        pickedUpItem = true;
        itemsBoard.enabled = false;

        GetComponent<CatMovement>().enableMovement();
        foodItem = null;
        normalItem = null;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pickedUpItem = false;
        ableToPickUp = false;
    }

    public void SetPickedUpItem(bool isItemPickedUp)
    {
        pickedUpItem = isItemPickedUp;
    }
}
