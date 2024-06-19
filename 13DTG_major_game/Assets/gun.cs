using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class gun : MonoBehaviour
{
    public Camera cam;
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem MuzzleFlash;
    public Camera PlayerCam;
    public AudioSource gunshotSound;
    public Animator gunAnimator;
    public AudioSource reloadSound;
    public float recoilForce = 0.1f;

    private bool isReloading = false;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        gunshotSound = audioSources[0]; 
        reloadSound = audioSources[1]; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click.");
            cam.fieldOfView = 50.0f;
        }

    }
    public void Shoot()
    {
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }


        gunshotSound.Play();

    }

    void Reload()
    {
        if (!isReloading)
        {
            isReloading = true;
            gunAnimator.SetTrigger("Reload"); // Trigger reload animation

            // Play reload sound
            reloadSound.Play();

            // Delay for the duration of the reload animation
            float reloadDuration = gunAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            StartCoroutine(CompleteReload(reloadDuration));
        }
    }

    IEnumerator CompleteReload(float duration)
    {
        yield return new WaitForSeconds(duration);
        isReloading = false;
    }
}
