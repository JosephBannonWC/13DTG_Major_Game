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
    public GameObject resetButton;
    public GameObject volume;
    public Transform playerHome;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    
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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reset()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerHome.position;
        player.transform.rotation = playerHome.rotation;
        Resume();

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        backButton.SetActive(false);
        volume.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        resumeButton.SetActive(true);
        resetButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void settings()
    {
        resumeButton.SetActive(false);
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        settingsButton.SetActive(false);
        backButton.SetActive(true);
        volume.SetActive(true);
    }
    public void back()
    {
        resumeButton.SetActive(true);
        resetButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        backButton.SetActive(false);
        volume.SetActive(false); 
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
