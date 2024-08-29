using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using System;

public class UIStopWatch : MonoBehaviour
{
    private bool _timerActive; // Indicates whether the timer is currently active
    private float _currentTime; // The current elapsed time
    private float PBtime; // Personal Best time stored in PlayerPrefs

    [SerializeField] private TMP_Text _text; // Reference to the TextMeshPro component for displaying the current time
    [SerializeField] private TMP_Text _pbText; // Reference to the TextMeshPro component for displaying the Personal Best time

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0; // Initialize current time to zero
        PBtime = PlayerPrefs.GetFloat("PBtime", float.MaxValue); // Retrieve PBtime from PlayerPrefs or set to maximum float value if not set
        DisplayPBTime(); // Display the Personal Best time on the UI
        Debug.Log("PBtime: " + PBtime); // Log the Personal Best time for debugging
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTimer(); // Reset the timer when the 'R' key is pressed
        }

        if (_timerActive)
        {
            _currentTime += Time.deltaTime; // Increment current time by the time elapsed since the last frame
        }

        // Format the current time and update the UI text
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.ToString(@"mm\:ss\:fff");
    }

    // Method to start the timer
    public void StartTimer()
    {
        _timerActive = true; // Set the timer to active
    }

    // Method to stop the timer
    public void StopTimer()
    {
        _timerActive = false; // Set the timer to inactive
        CheckPB(); // Check if the current time is a new Personal Best
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        _currentTime = 0; // Set the current time back to zero
    }

    // Method to check and update the Personal Best time
    private void CheckPB()
    {
        if (_currentTime < PBtime)
        {
            PBtime = _currentTime; // Update PBtime if the current time is better
            PlayerPrefs.SetFloat("PBtime", PBtime); // Save the new PBtime to PlayerPrefs
            PlayerPrefs.Save(); // Ensure changes are saved
            DisplayPBTime(); // Update the UI with the new PBtime
            Debug.Log("New PBtime: " + PBtime); // Log the new Personal Best time for debugging
        }
    }

    // Method to display the Personal Best time
    private void DisplayPBTime()
    {
        if (PBtime == float.MaxValue)
        {
            _pbText.text = "No PB yet"; // Display message if no Personal Best time is set
        }
        else
        {
            TimeSpan pbTimeSpan = TimeSpan.FromSeconds(PBtime); // Convert PBtime to TimeSpan format
            _pbText.text = pbTimeSpan.ToString(@"mm\:ss\:fff"); // Update UI text with the Personal Best time
        }
    }

    // Method to get the current time
    public float CurrentTime()
    {
        return _currentTime; // Return the current elapsed time
    }
}
