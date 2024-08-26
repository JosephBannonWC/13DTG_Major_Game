using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public AudioSource hitSound;
    public Animator animator;
    public string hitTriggerName = "doorOpen";
    public string doorTag = "doorTag";
    public string invalidSpace = "invalidSpace";
    public pointSystem pointSystem;
    public delegate void TargetDestroyed();
    public event TargetDestroyed onDestroyed;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        hitSound.Play();
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        
        onDestroyed?.Invoke();
        if (CompareTag(doorTag))
        {
            animator.SetTrigger(hitTriggerName);
            Destroy (gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
        if (CompareTag(invalidSpace))
        {
            if (pointSystem != null)
            {
                pointSystem.PlusPoint();
            }
            Destroy(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
