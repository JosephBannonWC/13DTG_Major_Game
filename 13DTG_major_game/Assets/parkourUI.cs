using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkourUI : MonoBehaviour
{
    // UI elements to be activated or deactivated
    public GameObject stopwatchUI;
    public GameObject pb;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the UI elements
        stopwatchUI.SetActive(false);
        pb.SetActive(false);
    }

    // Update is called once per frame
   

    // Called when a collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider col)
    {
        // Check if the colliding object has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // Show the stopwatch UI and personal best UI
            stopwatchUI.SetActive(true);
            pb.SetActive(true);
        }
    }

    // Called when a collider exits the trigger collider attached to this GameObject
    void OnTriggerExit(Collider col)
    {
        // Check if the colliding object has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // Hide the stopwatch UI and personal best UI
            stopwatchUI.SetActive(false);
            pb.SetActive(false);
        }
    }
}
