using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    public float point; // The current score or points
    public TMP_Text scoreText; // UI element to display the score

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI(); // Initialize the UI with the current score
    }

    

    // Method to decrease the score by one
    public void MinusPoint()
    {
        if (point > 0) // Ensure the score doesn't go below zero
        {
            point -= 1; // Subtract one point
            Debug.Log("Point -1: " + point); // Log the new score
            UpdateScoreUI(); // Update the score display
        }
    }

    // Method to increase the score by one
    public void PlusPoint()
    {
        point += 1; // Add one point
        Debug.Log("Point +1: " + point); // Log the new score
        UpdateScoreUI(); // Update the score display
    }

    // Method to update the UI text with the current score
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + point.ToString(); // Set the score text to display the current score
    }
}
