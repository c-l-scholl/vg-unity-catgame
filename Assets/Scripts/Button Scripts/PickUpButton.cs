using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpButton : MonoBehaviour
{
    public void OnButtonClick() {
        Debug.Log("Item picked up!");
        
        transform.parent.gameObject.SetActive(false);
    }
}
