using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDropItem : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterInventory catInventory;
    void Start()
    {
        catInventory = GetComponent<CharacterInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X)) 
        {
            TransferItem();
        }
    }

    public void TransferItem() {
        if (!catInventory.inventory.IsEmpty()) {
            catInventory.inventory.DropItem(0);
            catInventory.SetPickedUpItem(false);
        }
    }
}
