using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopwatch : MonoBehaviour
{
    public UIStopWatch script; // Reference to the UIStopWatch script

    // Start is called before the first frame update
    void Start()
    {
        // Initialization can be done here if needed
    }
  

    // Called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider col)
    {
        // Check if the colliding object has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // Start the stopwatch timer from the UIStopWatch script
            script.StartTimer();
        }
    }
}
