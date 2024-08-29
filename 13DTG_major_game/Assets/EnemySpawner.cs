using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    // Slider to control the interval at which enemies are spawned
    public Slider spawnIntervalSlider;
    // Prefab of the enemy to be instantiated
    public GameObject enemyPrefab;
    // Center point around which enemies will be spawned
    public Transform centerPoint;
    // Interval between enemy spawns, adjustable via slider
    [Range(0f, 100f)] public float spawnInterval = 2f;
    // Counter for the number of enemies spawned
    private int enemiesSpawned = 0;
    // Maximum number of enemies that can be spawned
    private int maxEnemies = 2000;
    // Speed at which enemies move towards the center
    public float moveSpeed = 2f;
    // Radius around the center where enemies can be spawned
    public float spawnRadius = 10f;
    // Fixed y-coordinate for the spawn positions
    public float fixedY = -10f;

    // Called before the first frame update
    void Start()
    {
        // Set initial spawn interval and update it with slider value
        spawnInterval = 4;
        spawnInterval = spawnIntervalSlider.value;
        spawnIntervalSlider.onValueChanged.AddListener(UpdateSpawnInterval);
        // Start the enemy spawning coroutine
        StartCoroutine(SpawnEnemies());
    }

    // Updates the spawn interval when slider value changes
    void UpdateSpawnInterval(float value)
    {
        spawnInterval = value;
    }

    // Coroutine to handle enemy spawning
    IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < maxEnemies)
        {
            // Determine a random spawn position around the center
            Vector3 spawnPosition = RandomSpawnPosition();
            // Instantiate the enemy at the spawn position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Calculate direction from spawn position to center
            Vector3 directionToCenter = (centerPoint.position - spawnPosition).normalized;
            // Set enemy's rotation to face the center
            enemy.transform.rotation = Quaternion.LookRotation(directionToCenter);

            // Start moving the enemy towards the center and destroy after 20 seconds
            StartCoroutine(MoveTowardsCenter(enemy, directionToCenter));
            StartCoroutine(DestroyAfterTime(enemy, 20f));

            // Increment the count of enemies spawned
            enemiesSpawned++;
            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Calculates a random position within a circular area around the center
    Vector3 RandomSpawnPosition()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float x = Mathf.Cos(angle) * spawnRadius;
        float z = Mathf.Sin(angle) * spawnRadius;
        float y = fixedY;
        Vector3 spawnPosition = new Vector3(x, 0, z) + centerPoint.position;
        return spawnPosition;
    }

    // Coroutine to move the enemy towards the center
    IEnumerator MoveTowardsCenter(GameObject enemy, Vector3 directionToCenter)
    {
        while (enemy != null)
        {
            // Move the enemy in the direction of the center
            enemy.transform.position += directionToCenter * moveSpeed * Time.deltaTime;
            yield return null; // Wait until the next frame
        }
    }

    // Coroutine to destroy the enemy after a specified time
    IEnumerator DestroyAfterTime(GameObject enemy, float time)
    {
        yield return new WaitForSeconds(time);
        if (enemy != null)
        {
            Destroy(enemy);
        }
    }
}
