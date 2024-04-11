using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeMultiplier;
    public float startTime;
    public TextMeshProUGUI timeText;
    private DateTime currentTime;
    private float secondsSum;
    private readonly float SECONDS_TO_ADD = 300f;
    public UnityEvent sleepCutscene;
    public UnityEvent startSunset;
    public UnityEvent startDarkness;
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startTime);
        timeText.text = currentTime.ToString("HH:mm");
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsSum >= SECONDS_TO_ADD) {
            UpdateTimeOfDay(SECONDS_TO_ADD);
            secondsSum = 0;
        }
        secondsSum += Time.deltaTime * timeMultiplier;
        if (currentTime >= DateTime.Now.Date + TimeSpan.FromHours(startTime + 15f))
        {
            ResetTimeToMorning();
        }

        if (currentTime >= DateTime.Now.Date + TimeSpan.FromHours(startTime + 9f))
        {
            startSunset.Invoke();
        }

        if (currentTime >= DateTime.Now.Date + TimeSpan.FromHours(startTime + 11f))
        {
            startDarkness.Invoke();
        }

    }

    public void ResetTimeToMorning()
    {
        sleepCutscene.Invoke();
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startTime);
    }

    private void UpdateTimeOfDay(float seconds)
    {   
        currentTime = currentTime.AddSeconds(seconds);
        if (timeText != null) 
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }
}