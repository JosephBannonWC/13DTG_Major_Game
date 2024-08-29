using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopTimer : MonoBehaviour
{
    public UIStopWatch stop; // Reference to the UIStopWatch script managing the timer
    private float _PBTime; // Variable to store the player's best time

    [SerializeField] private TMP_Text _text; // Reference to the TextMeshPro UI element for displaying the time

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be added here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Convert the recorded time to a TimeSpan for formatting
        TimeSpan time = TimeSpan.FromSeconds(_PBTime);
        // Update the UI text with the formatted time (mm:ss:fff)
        _text.text = time.ToString(@"mm\:ss\:fff");
    }

    void OnTriggerEnter(Collider col)
    {
        // Check if the object that triggered the collision has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // Record the player's best time from the stopwatch
            _PBTime = stop.CurrentTime();
            // Stop and reset the stopwatch
            stop.StopTimer();
            stop.ResetTimer();
        }
    }
}
