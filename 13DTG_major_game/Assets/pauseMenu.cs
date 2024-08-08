using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject backButton;

    // Start is called before the first frame update
    private void Start()
    {
        // Ensure the pause menu is not active when the game starts
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        // Ensure the cursor is locked and hidden at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Lock and hide the cursor when resuming the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        backButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;

        // Unlock and show the cursor when pausing the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void settings()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
        settingsButton.SetActive(false);
        backButton.SetActive(true);
    }
    public void back()
    {
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        backButton.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
