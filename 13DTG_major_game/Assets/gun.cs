using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class gun : MonoBehaviour
{
    public Camera cam; // Reference to the camera used for aiming
    public float damage = 10f; // Damage dealt by the gun
    public float range = 100f; // Maximum range of the gun
    public ParticleSystem MuzzleFlash; // Particle system for the gun's muzzle flash
    public Camera PlayerCam; // Camera used for raycasting
    public AudioSource gunshotSound; // Audio source for the gunshot sound
    public Animator gunAnimator; // Animator for the gun's reload animation
    public AudioSource reloadSound; // Audio source for the reload sound
    public float recoilForce = 0.1f; // Force applied for recoil (not used in this script)

    private bool isReloading = false; // Flag to check if the gun is currently reloading

    private void Start()
    {
        // Initialize audio sources by getting components attached to the gun
        AudioSource[] audioSources = GetComponents<AudioSource>();
        gunshotSound = audioSources[0];
        reloadSound = audioSources[1];
    }

    void Update()
    {
        // Reload the gun when the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            print("shoot");
            Debug.Log("shoot");
        }

        // Adjust the field of view when the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click.");
            cam.fieldOfView = 50.0f;
        }
    }

    public void Shoot()
    {
        // Play muzzle flash effect
        MuzzleFlash.Play();

        RaycastHit hit;
        Debug.Log("hit");

        // Perform a raycast from the player's camera forward direction
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // Check and apply damage to different types of targets
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            target1 target1 = hit.transform.GetComponent<target1>();
            if (target1 != null)
            {
                target1.TakeDamage(damage);
            }

            target2 target2 = hit.transform.GetComponent<target2>();
            if (target2 != null)
            {
                target2.TakeDamage(damage);
            }

            target3 target3 = hit.transform.GetComponent<target3>();
            if (target3 != null)
            {
                target3.TakeDamage(damage);
            }

            target4 target4 = hit.transform.GetComponent<target4>();
            if (target4 != null)
            {
                target4.TakeDamage(damage);
            }

            target5 target5 = hit.transform.GetComponent<target5>();
            if (target5 != null)
            {
                target5.TakeDamage(damage);
            }
        }

        // Play gunshot sound
        gunshotSound.Play();
    }

    void Reload()
    {
        Debug.Log("reloading");
        if (!isReloading)
        {
            isReloading = true;
            gunAnimator.SetTrigger("Reload"); // Trigger reload animation

            reloadSound.Play(); // Play reload sound

            // Get the duration of the reload animation and start coroutine to handle reload completion
            float reloadDuration = gunAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            StartCoroutine(CompleteReload(reloadDuration));
        }
    }

    IEnumerator CompleteReload(float duration)
    {
        // Wait for the reload duration to complete
        yield return new WaitForSeconds(duration);
        isReloading = false; // Reset reload flag
    }
}
