using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemScript : MonoBehaviour
{
    public bool food = false;
    public bool box = false;
    bool triggerActive = false;
    public GameObject popUpUI;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }
 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }
 
    private void Update() // we can get rid of the other functions
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space)) // and use the IsTouching() method instead of triggerActive
                                                            // unless you followed some tutorial and this is better practice idrk :)
                                                            // you can look NpcInteraction for reference
                                                            // - Camden
        {
            if (!box) {
                CatInventoryStuff();
            } else {
                BoxInteractionStuff();
            }
        }
    }
 
    void CatInventoryStuff()
    {
        PromptPlayer();
    }

    void BoxInteractionStuff() {

    }

    public void PromptPlayer() {

        if (food) {
            popUpUI.transform.Find("EatFood").gameObject.SetActive(true);
        }

        popUpUI.SetActive(true);

        if (!triggerActive) {
            popUpUI.SetActive(false);
        }
    }

}
