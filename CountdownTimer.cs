using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownDuration = 5.0f; // Countdown duration in minutes

    private float startTime;
    private float timeRemaining;

    public float RemainingTime;

    void Start()
    {
        startTime = Time.time;
        timeRemaining = countdownDuration * 60; // Convert minutes to seconds
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = timeRemaining - elapsedTime;

        if (remainingTime <= 0)
        {
            timerText.text = "00:00:00";
            // Handle time's up logic here
        }
        else
        {
            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);
            int milliseconds = (int)((remainingTime * 100) % 100);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
        RemainingTime = remainingTime;
    }
}


