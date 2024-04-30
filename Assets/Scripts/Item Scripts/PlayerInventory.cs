using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public Canvas catBagCanvas;
    private UIInventory catBagUI;
    private GameObject eatButton;
    private GameObject swapButton;
    private GameObject pickUpButton;
    private ConsumableItem foodItem;
    private CollectableItem normalItem;
    private bool pickedUpItem = false;
    private bool ableToPickUp = false;
    private bool backstory = false;

    // public UnityEvent addHealthFromFood;
    void Start()
    {
        catBagUI = catBagCanvas.GetComponentInChildren<UIInventory>();
        eatButton = catBagCanvas.transform.Find("EatButton").gameObject;
        swapButton = catBagCanvas.transform.Find("SwapButton").gameObject;
        pickUpButton = catBagCanvas.transform.Find("PickupButton").gameObject;
    }

    void Update()
    {
        if (catBagCanvas.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                GetComponent<CatMovement>().enableMovement();
                catBagCanvas.gameObject.SetActive(false);
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

        if (Input.GetKey(KeyCode.Space) && ableToPickUp)
        {
            GetComponent<CatMovement>().disableMovement();
            catBagCanvas.gameObject.SetActive(true);
        }
    }

    public void OnOptionClicked(int selection)
    {
        switch (selection)
        {
            case 0: // eat
                foodItem.destroyItem();
                GetComponent<CatHealth>().AddHealthFromFood();
                if (GetComponent<EatBackstoryPrompt>().RandomBackStory())
                {
                    backstory = true;
                }
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
        catBagCanvas.gameObject.SetActive(false);
        if (!backstory)
        {
            GetComponent<CatMovement>().enableMovement();
        }
        foodItem = null;
        normalItem = null;
        backstory = false;
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
