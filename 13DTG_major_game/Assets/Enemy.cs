using UnityEngine;

public class Enemy : MonoBehaviour
{
    public pointSystem pointSystem;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("invalidSpace"))
        {
            if (pointSystem != null)
            {
                pointSystem.MinusPoint();
            }
            else
            {
                Debug.LogError("PointSystem reference is missing.");
            }

            Destroy(col.gameObject);
        }
    }

    void Start()
    {
        // Optionally find the pointSystem dynamically if not assigned
        if (pointSystem == null)
        {
            pointSystem = FindObjectOfType<pointSystem>();
            if (pointSystem == null)
            {
                Debug.LogError("PointSystem not found in the scene.");
            }
        }
    }
}
