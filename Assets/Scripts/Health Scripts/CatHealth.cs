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
    private readonly float HEALTH_FROM_FOOD = 4.5f;
    private readonly float TIME_TO_DECREASE_HEALTH = 200f;

    void Start()
    {
        currentHP = maxHP / 2;
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
    }

    void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        currentHP -= Time.deltaTime / TIME_TO_DECREASE_HEALTH;
        // healthSlider.value = Mathf.SmoothDamp(healthSlider.value, currentHP, ref 1f, 1f);
        healthSlider.value = currentHP;
    }

    public void AddHealthFromFood()
    {
        currentHP += HEALTH_FROM_FOOD;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
