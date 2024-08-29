using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; // The health of the target
    public AudioSource hitSound; // AudioSource for the hit sound effect
    public Animator animator; // Animator to control animations
    public string hitTriggerName = "doorOpen"; // Trigger name for door animation
    public string doorTag = "doorTag"; // Tag for identifying door targets
    public string invalidSpace = "invalidSpace"; // Tag for identifying invalid space targets
    public pointSystem pointSystem; // Reference to the point system for scoring
    public delegate void TargetDestroyed(); // Delegate for the onDestroyed event
    public event TargetDestroyed onDestroyed; // Event that triggers when the target is destroyed

    // Start is called before the first frame update
    private void Start()
    {
        // Get all AudioSource components attached to this GameObject
        AudioSource[] audioSources = GetComponents<AudioSource>();
        hitSound = audioSources[0]; // Assign the first AudioSource to hitSound
    }

    // Method to apply damage to the target
    public void TakeDamage(float amount)
    {
        health -= amount; // Reduce the health by the damage amount
        hitSound.Play(); // Play the hit sound effect
        if (health <= 0f)
        {
            Die(); // Call Die method if health drops to zero or below
        }
    }

    // Method to handle the target's death
    void Die()
    {
        onDestroyed?.Invoke(); // Trigger the onDestroyed event if there are subscribers

        // Check if the target is tagged as a door
        if (CompareTag(doorTag))
        {
            animator.SetTrigger(hitTriggerName); // Trigger the door animation
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length); // Destroy the target after the animation finishes
        }
        // Check if the target is tagged as invalid space
        else if (CompareTag(invalidSpace))
        {
            if (pointSystem != null)
            {
                pointSystem.PlusPoint(); // Add a point to the point system if it exists
            }
            Destroy(gameObject); // Destroy the target immediately
        }
        else
        {
            Destroy(gameObject); // Destroy the target if it is neither a door nor an invalid space
        }
    }
}
