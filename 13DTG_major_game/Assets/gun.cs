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
            print("shoot");
            Debug.Log("shoot");
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
        Debug.Log("hit");
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

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


        gunshotSound.Play();

    }

    void Reload()
    {
        Debug.Log("reloading");
        if (!isReloading)
        {
            isReloading = true;
            gunAnimator.SetTrigger("Reload"); 

            // Play reload sound
            reloadSound.Play();

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
