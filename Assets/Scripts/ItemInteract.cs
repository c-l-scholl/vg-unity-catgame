// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class ItemInteract : MonoBehaviour
// {
//     public bool food = false;
//     public bool box = false;
//     public GameObject popUpUI;
//     private BoxCollider2D interactionBox;
//     private BoxCollider2D catCollider;
//     private bool pickedUpItem;

//     void Start()
//     {
//         interactionBox = GetComponent<BoxCollider2D>();
//         //catCollider = CatSingleton.GetCatSingleton().GetCatCollider();
//     }

//     void Update()
//     {
//         if (interactionBox.IsTouching(catCollider)) // change to onTriggerStay for better efficiency
//         {
//             if (!pickedUpItem && Input.GetKey(KeyCode.Space))
//             {
//                 Debug.Log("Interacted with item");
//                 // Show GUI
//                 // Display Options
//                 // will fix this later

//                 //pickedUpItem = CatSingleton.GetCatSingleton().GetInventory().AddItemToInventory(this.gameObject);
//                 if (pickedUpItem)
//                 {
//                     this.gameObject.SetActive(false);
//                     Debug.Log("Picked up item");
//                 }
//                 pickedUpItem = true;
//             }
//         }
//         else
//         {
//             pickedUpItem = false;
//         }

//     }

    // public void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("Player"))
    //     {
    //         triggerActive = true;
    //     }
    // }

    // public void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         triggerActive = false;
    //     }
    // }

    // private void Update() // we can get rid of the other functions
    // {
    //     if (triggerActive && Input.GetKeyDown(KeyCode.Space)) // and use the IsTouching() method instead of triggerActive
    //                                                         // unless you followed some tutorial and this is better practice idrk :)
    //                                                         // you can look NpcInteraction for reference
    //                                                         // - Camden
    //     {
    //         if (!box) {
    //             CatInventoryStuff();
    //         } else {
    //             BoxInteractionStuff();
    //         }
    //     }
    // }

    // void CatInventoryStuff()
    // {
    //     PromptPlayer();
    // }

    // void BoxInteractionStuff()
    // {

    // }

    // public void PromptPlayer()
    // {

    //     if (food)
    //     {
    //         popUpUI.transform.Find("EatFood").gameObject.SetActive(true);
    //     }

    //     popUpUI.SetActive(true);

    //     if (!triggerActive)
    //     {
    //         popUpUI.SetActive(false);
    //     }
    // }

//}
