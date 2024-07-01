using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIStopWatch : MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    [SerializeField] private TMP_Text _text; 
    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }
        _text.text = _currentTime.ToString();
    }
    public void StartTimer()
    {
        _timerActive = true;
    }
    public void StopTimer()
    {
        _timerActive = false;
        Invoke("delay", 3);
        _currentTime = 0;

    }
    public void CurrentTime()
    {
        _currentTime;

    }

}
