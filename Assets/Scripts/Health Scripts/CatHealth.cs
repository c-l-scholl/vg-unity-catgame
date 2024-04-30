using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CatHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthSlider;
    public float maxHP = 9;
    private float currentHP;
    private float elapsed;
    private readonly float HEALTH_FROM_FOOD = 1f;
    private readonly float TIME_TO_DECREASE_HEALTH = 100f;
    private readonly float DAMAGE = 3f;

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

    void ResetScene()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    private void UpdateHealth()
    {
        currentHP -= Time.deltaTime / TIME_TO_DECREASE_HEALTH;
        // healthSlider.value = Mathf.SmoothDamp(healthSlider.value, currentHP, ref 1f, 1f);
        healthSlider.value = currentHP;

        if (currentHP <= 0.01f) 
        {
            ResetScene();
        }
    }

    public void ResetHealth() 
    {
        currentHP = maxHP / 2;
        healthSlider.maxValue = maxHP;
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

    public void DecreaseHealth()
    {
        currentHP -= DAMAGE;
    }
}
