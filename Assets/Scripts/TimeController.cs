using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeMultiplier;
    public float startTime;
    public TextMeshProUGUI timeText;
    private DateTime currentTime;
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startTime);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (timeText != null) 
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }
}
