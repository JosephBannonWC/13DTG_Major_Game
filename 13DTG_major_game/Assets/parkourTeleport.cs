using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkourTeleport : MonoBehaviour
{
    

    // Called when another collider enters this collider's trigger
    void OnTriggerEnter(Collider col)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            // Teleport the player to the specified position
            col.transform.position = new Vector3(-10.7f, 2.7f, -29.01f);
        }
    }
}
