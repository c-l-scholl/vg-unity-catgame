using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[CreateAssetMenu(fileName = "NewHealthTracker", menuName = "Health Tracker")]
public class HealthTracker : ScriptableObject
{
    public int maxHP = 9;
    private int currentHP;
    private float elapsed;
    private readonly float TIME_TO_DECREASE_HEALTH = 10f;


    void Start()
    {
        currentHP = maxHP;
        elapsed = 0f;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= TIME_TO_DECREASE_HEALTH)
        {
            elapsed = elapsed % TIME_TO_DECREASE_HEALTH;
            UpdateHealth();
        }
    }

    private void UpdateHealth()
    {
        currentHP -= 1;

        if (currentHP <= 0) 
        {
            Debug.Log("You died lol");
            // add death method here
        }
    }


    


}