using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public AudioSource hitSound;
    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0];
    }
    public void TakeDamage(float amount)
    {
        hitSound.Play();
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}