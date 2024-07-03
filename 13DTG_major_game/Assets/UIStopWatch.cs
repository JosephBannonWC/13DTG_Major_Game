using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIStopWatch : MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    private float PBtime;

[SerializeField] private TMP_Text _text;
    // Start is called before the first frame update
    void Start() => _currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = _currentTime.ToString();
    }
    public void StartTimer()
    {
        _timerActive = true;
    }
    public void StopTimer()
    {
        _timerActive = false;
        _currentTime = 0;

    }
    public float CurrentTime()
    {
        return _currentTime;
    }
}
