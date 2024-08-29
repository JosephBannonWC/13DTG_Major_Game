using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volume; // Reference to the volume slider UI element

    // Start is called before the first frame update
    void Start()
    {
        // Check if "MusicVolume" key exists in PlayerPrefs
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            // If not, set a default value and load the settings
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            // If key exists, just load the settings
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Currently empty; can be removed if not used
    }

    // Method called when the slider value changes
    public void volumeSlider()
    {
        // Set the AudioListener volume to the slider's value
        AudioListener.volume = volume.value;
        // Save the current volume setting
        Save();
    }

    // Load volume setting from PlayerPrefs
    private void Load()
    {
        // Set the slider's value based on the saved volume setting
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Save the current volume setting to PlayerPrefs
    private void Save()
    {
        // Save the slider's value as "MusicVolume" in PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume.value);
    }
}
