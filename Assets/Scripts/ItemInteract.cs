using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public bool food = false;
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
 
    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.X))
        {
            CatInventoryStuff();
        }
    }
 
    public void CatInventoryStuff()
    {
        PromptPlayer();
    }

    public void PromptPlayer() {
        popUpUI.SetActive(true);

        if (!triggerActive) {
            popUpUI.SetActive(false);
        }
    }

}
