using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopTimer : MonoBehaviour
{
    public UIStopWatch stop;
    private float _PBTime;

    [SerializeField] private TMP_Text __text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        __text.text = _PBTime.ToString();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _PBTime = stop.CurrentTime();

            stop.StopTimer();

        }
    }
}
