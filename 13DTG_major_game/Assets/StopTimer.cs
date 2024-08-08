using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopTimer : MonoBehaviour
{
    public UIStopWatch stop;
    private float _PBTime;

    [SerializeField] private TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(_PBTime);
        _text.text = time.ToString(@"mm\:ss\:fff");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _PBTime = stop.CurrentTime();
            stop.StopTimer();
            stop.ResetTimer();
        }
    }
}
