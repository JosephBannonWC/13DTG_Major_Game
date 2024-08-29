using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Static variable to track the paused state of the game
    public static bool isPaused = false;

    // References to UI elements for the pause menu
    public GameObject pauseMenuUI;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject backButton;
    public GameObject resetButton;
    public GameObject volume;
    public Transform playerHome;
    public GameObject resetTimer;
    public GameObject enemySlider;
    public GameObject sizeSlider;

    // Called before the first frame update
    private void Start()
    {
        // Initially hide the pause menu and ensure game is not paused
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called once per frame
    void Update()
    {
        // Toggle pause state when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false; // Set the pause state to false

        // Lock the cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Method to reset the player position and rotation, then resume the game
    public void Reset()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerHome.position; // Move player to home position
        player.transform.rotation = playerHome.rotation; // Reset player rotation
        Resume(); // Resume the game
    }

    // Method to pause the game and show the pause menu
    public void Pause()
    {
        sizeSlider.SetActive(false); // Hide size slider
        enemySlider.SetActive(false); // Hide enemy slider
        resetTimer.SetActive(true); // Show reset timer
        pauseMenuUI.SetActive(true); // Show the pause menu
        backButton.SetActive(false); // Hide the back button
        volume.SetActive(false); // Hide volume controls
        Time.timeScale = 0f; // Freeze game time
        isPaused = true; // Set the pause state to true
        resumeButton.SetActive(true); // Show resume button
        resetButton.SetActive(true); // Show reset button
        quitButton.SetActive(true); // Show quit button
        settingsButton.SetActive(true); // Show settings button
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }

    // Method to show the settings menu and hide other UI elements
    public void settings()
    {
        sizeSlider.SetActive(true); // Show size slider
        enemySlider.SetActive(true); // Show enemy slider
        resetTimer.SetActive(false); // Hide reset timer
        resumeButton.SetActive(false); // Hide resume button
        resetButton.SetActive(false); // Hide reset button
        quitButton.SetActive(false); // Hide quit button
        settingsButton.SetActive(false); // Hide settings button
        backButton.SetActive(true); // Show back button
        volume.SetActive(true); // Show volume controls
    }

    // Method to go back from the settings menu to the pause menu
    public void back()
    {
        sizeSlider.SetActive(false); // Hide size slider
        enemySlider.SetActive(false); // Hide enemy slider
        resetTimer.SetActive(true); // Show reset timer
        resumeButton.SetActive(true); // Show resume button
        resetButton.SetActive(true); // Show reset button
        quitButton.SetActive(true); // Show quit button
        settingsButton.SetActive(true); // Show settings button
        backButton.SetActive(false); // Hide back button
        volume.SetActive(false); // Hide volume controls
    }

    // Method to quit the game and load the previous scene
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Load the previous scene
    }
}
