using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using System;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
public class crouch : MonoBehaviour
{
 
    public CharacterController PlayerHeight;
    bool _groundedPlayer;
    public float normalHeight, crouchHeight;
    public GameObject rightleg;
    public GameObject leftleg;
    public FirstPersonController firstPersonController;
    public GameObject player;
    

    public float minimum = -1.0F;
    public float maximum = 1.0F;
    void Start()
    {
        rightleg.SetActive(false);
        leftleg.SetActive(false);
    }
   
    void Update()
    {
        _groundedPlayer = PlayerHeight.isGrounded;
        if (Input.GetKeyDown(KeyCode.C) && _groundedPlayer)
        {
            Debug.Log("slide");
            firstPersonController.MoveSpeed = (20f);
            PlayerHeight.height = crouchHeight;
            rightleg.SetActive(true);
            leftleg.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyDown(KeyCode.Space))
        {
            firstPersonController.MoveSpeed = 5f;
            PlayerHeight.height = normalHeight;
            leftleg.SetActive(false);
            rightleg.SetActive(false);
            
        }
    }
}