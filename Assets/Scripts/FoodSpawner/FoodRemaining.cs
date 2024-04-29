using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodRemaining : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI foodRemainingText;
    [SerializeField]
    private GameObject foodManager;
    private int foodRemaining;
    void Awake()
    {
        foodRemaining = foodManager.GetComponent<FoodSpawner>().CalculateRemainingFood();
        foodRemainingText.text = "Food for tomorrow: " + foodRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
