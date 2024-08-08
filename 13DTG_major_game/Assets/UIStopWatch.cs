using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using System;

public class UIStopWatch : MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    private float PBtime;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _pbText;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
        PBtime = PlayerPrefs.GetFloat("PBtime", float.MaxValue);
        DisplayPBTime();
        Debug.Log("Loaded PBtime: " + PBtime);
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTimer();
        }
    if (_timerActive)
        {
            _currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartTimer()
    {
        _timerActive = true;
    }

    public void StopTimer()
    {
        _timerActive = false;
        CheckPB();
    }

    public void ResetTimer()
    {
        _currentTime = 0;
    }

    private void CheckPB()
    {
        if (_currentTime < PBtime)
        {
            PBtime = _currentTime;
            PlayerPrefs.SetFloat("PBtime", PBtime);
            PlayerPrefs.Save();
            DisplayPBTime();
            Debug.Log("New PBtime: " + PBtime);
        }
    }

    private void DisplayPBTime()
    {
        if (PBtime == float.MaxValue)
        {
            _pbText.text = "No PB yet";
        }
        else
        {
            TimeSpan pbTimeSpan = TimeSpan.FromSeconds(PBtime);
            _pbText.text = pbTimeSpan.ToString(@"mm\:ss\:fff");
        }
    }

    public float CurrentTime()
    {
        return _currentTime;
    }
}
