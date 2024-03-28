using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CatHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI healthText;
    public int maxHP = 9;
    private int currentHP;
    private float elapsed;
    private readonly float TIME_TO_DECREASE_HEALTH = 225f;

    void Start()
    {
        currentHP = maxHP;
        elapsed = 0f;
        healthText.text = "Health: " + maxHP;
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
        healthText.text = "Health: " + currentHP;

        if (currentHP <= 0)
        {
            Debug.Log("You died lol");
            // add death method here
        }
    }
}
