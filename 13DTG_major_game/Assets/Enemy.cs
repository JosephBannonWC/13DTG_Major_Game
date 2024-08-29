using UnityEngine;

public class Enemy : MonoBehaviour
{
    public pointSystem pointSystem; // Reference to the pointSystem for managing points

    // Called when the collider attached to this GameObject collides with another collider
    void OnCollisionEnter(Collision col)
    {
        // Check if the colliding object has the tag "invalidSpace"
        if (col.gameObject.CompareTag("invalidSpace"))
        {
            // If pointSystem is assigned, decrease the player's points
            if (pointSystem != null)
            {
                pointSystem.MinusPoint();
            }
            else
            {
                // Log an error if pointSystem reference is missing
                Debug.LogError("PointSystem reference is missing.");
            }

            // Destroy the colliding GameObject
            Destroy(col.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Optionally find the pointSystem dynamically if it is not assigned in the Inspector
        if (pointSystem == null)
        {
            pointSystem = FindObjectOfType<pointSystem>();
            if (pointSystem == null)
            {
                // Log an error if pointSystem is not found in the scene
                Debug.LogError("PointSystem not found in the scene.");
            }
        }
    }
}
