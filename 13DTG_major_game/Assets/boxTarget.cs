using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTarget : MonoBehaviour
{
    public GameObject targetPrefab; // The prefab used for the target objects
    public Transform spawnArea; // The area within which targets will be spawned
    [Range(0f, 100f)] public float spawnInterval = 2f; // Time interval between spawns
    private int targetsShot = 0; // Counter for how many targets have been shot
    private int maxTargets = 30; // Maximum number of targets to spawn
    private GameObject currentTarget; // Reference to the currently spawned target

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to spawn targets
        StartCoroutine(SpawnTargets());
    }

    // Coroutine to handle target spawning
    IEnumerator SpawnTargets()
    {
        // Loop until the maximum number of targets have been shot
        while (targetsShot < maxTargets)
        {
            // Only spawn a new target if there isn't a current target
            if (currentTarget == null)
            {
                // Calculate a random position within the spawn area
                Vector3 position = new Vector3(
                    Random.Range(spawnArea.position.x - 10f, spawnArea.position.x + 10f),
                    Random.Range(spawnArea.position.y, spawnArea.position.y + 0.01f),
                    Random.Range(spawnArea.position.z, spawnArea.position.z + 10f)
                );

                // Instantiate a new target at the calculated position
                currentTarget = Instantiate(targetPrefab, position, Quaternion.identity);

                // Subscribe to the target's onDestroyed event
                currentTarget.GetComponent<Target>().onDestroyed += OnTargetDestroyed;
            }

            // Wait until the next frame
            yield return null;
        }

        // Log a message when all targets have been shot
        Debug.Log("all targets shot");
    }

    // Callback method for when a target is destroyed
    void OnTargetDestroyed()
    {
        // Increment the targetsShot counter
        targetsShot++;

        // Unsubscribe from the onDestroyed event to prevent memory leaks
        currentTarget.GetComponent<Target>().onDestroyed -= OnTargetDestroyed;

        // Set currentTarget to null to allow spawning of new targets
        currentTarget = null;
    }
}
