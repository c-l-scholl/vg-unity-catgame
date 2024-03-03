using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapButton : MonoBehaviour
{
    public void OnButtonClick() {
        Debug.Log("Items swapped!");
        
        transform.parent.gameObject.SetActive(false);
    }
}
