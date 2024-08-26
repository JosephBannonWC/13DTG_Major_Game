using UnityEngine;

public class target2 : MonoBehaviour
{
    public float health = 50f;
    public AudioClip hitClip;
    public AudioSource hitSound1;
    public Animator animator;
    public delegate void TargetDestroyed();
    public event TargetDestroyed onDestroyed;

    private void Start()
    {
        hitSound1 = GetComponent<AudioSource>();
        if (hitSound1 == null)
        {
            Debug.LogError("AudioSource component missing on this GameObject.");
        }

    }

    public void TakeDamage(float amount)
    {
        Debug.Log("damage");
        hitSound1.Play();
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {

        onDestroyed?.Invoke();




        Destroy(gameObject);

    }
}
