using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthSlider;
    public float maxHP = 9;
    private float currentHP;
    private float elapsed;
    private readonly float TIME_TO_DECREASE_HEALTH = 200f;

    void Start()
    {
        currentHP = maxHP / 2;
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
    }

    void Update()
    {
        // elapsed += Time.deltaTime;
        // if (elapsed >= TIME_TO_DECREASE_HEALTH)
        // {
        //     elapsed = elapsed % TIME_TO_DECREASE_HEALTH;
        //     UpdateHealth();
        // }
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        currentHP -= Time.deltaTime / TIME_TO_DECREASE_HEALTH;
        healthSlider.value = currentHP;
    }

    // {
    //     currentHP -= 1;
    //     healthText.text = "Health: " + currentHP;

    //     if (currentHP <= 0)
    //     {
    //         Debug.Log("You died lol");
    //         // add death method here
    //     }
    // }
}
