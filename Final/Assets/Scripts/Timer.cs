using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 0; // Adjust the total time as needed
    private float currentTime;

    void Start()
    {
        // Initialize the timer
        currentTime = totalTime;
    }

    void Update()
    {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Update the TextMeshPro Text component with the current time
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
    }
}
