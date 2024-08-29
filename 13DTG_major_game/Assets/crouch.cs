using StarterAssets; // Import StarterAssets namespace for accessing character control components
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering; // Import for rendering-related features (may not be needed)
using UnityEngine;
using System;
using UnityEngine.InputSystem.Controls; // Import for InputSystem controls (may not be needed)
using UnityEngine.InputSystem; // Import for InputSystem

public class crouch : MonoBehaviour
{
    public CharacterController PlayerHeight; // Reference to the CharacterController component controlling player height
    bool _groundedPlayer; // Boolean to check if the player is on the ground
    public float normalHeight, crouchHeight; // Heights for normal stance and crouching
    public GameObject rightleg; // Reference to the GameObject representing the right leg
    public GameObject leftleg; // Reference to the GameObject representing the left leg
    public FirstPersonController firstPersonController; // Reference to the FirstPersonController component for controlling movement
    public GameObject player; // Reference to the player GameObject (not used in this script)

    public float minimum = -1.0F; // Minimum value (not used in this script)
    public float maximum = 1.0F; // Maximum value (not used in this script)

    // Start is called before the first frame update
    void Start()
    {
        // Hide the leg GameObjects at the start
        rightleg.SetActive(false);
        leftleg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        _groundedPlayer = PlayerHeight.isGrounded;

        // Check if the crouch key (C) is pressed and the player is on the ground
        if (Input.GetKeyDown(KeyCode.C) && _groundedPlayer)
        {
            Debug.Log("slide"); // Log a message for debugging
            // Set movement speed for crouching
            firstPersonController.MoveSpeed = (20f);
            // Set the player's height to crouch height
            PlayerHeight.height = crouchHeight;
            // Show the leg GameObjects to represent crouching
            rightleg.SetActive(true);
            leftleg.SetActive(true);
        }

        // Check if the crouch key (C) is released or the jump key (Space) is pressed
        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyDown(KeyCode.Space))
        {
            // Reset movement speed to normal
            firstPersonController.MoveSpeed = 5f;
            // Set the player's height back to normal
            PlayerHeight.height = normalHeight;
            // Hide the leg GameObjects
            leftleg.SetActive(false);
            rightleg.SetActive(false);
        }
    }
}
