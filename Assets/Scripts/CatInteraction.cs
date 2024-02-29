using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatUI : MonoBehaviour
{
    string[] inventory;
    bool carrying;
    bool food; //can differentiate items by food or not-food
    
    void Start()
    {
        inventory = new string[1];
        carrying = false;
        food = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickUp(string item) {
        carrying = true;
        // if (item)
    }

}
