using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();

        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void volumeSlider()
    {
        AudioListener.volume = volume.value;
        Save();
    }
    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volume.value);
    }
}
