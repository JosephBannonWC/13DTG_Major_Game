using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform centerPoint;
    [Range(0f, 100f)] public float spawnInterval = 2f;
    private int enemiesSpawned = 0;
    private int maxEnemies = 30;
    public float moveSpeed = 2f;
    public float spawnRadius = 10f;
    public float fixedY = -10f;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < maxEnemies)
        {
            Vector3 spawnPosition = RandomSpawnPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Vector3 directionToCenter = (centerPoint.position - spawnPosition).normalized;
            enemy.transform.rotation = Quaternion.LookRotation(directionToCenter);

            StartCoroutine(MoveTowardsCenter(enemy, directionToCenter));

            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float x = Mathf.Cos(angle) * spawnRadius;
        float z = Mathf.Sin(angle) * spawnRadius;
        float y = fixedY;
        Vector3 spawnPosition = new Vector3(x, 0, z) + centerPoint.position;
        return spawnPosition;
    }

    IEnumerator MoveTowardsCenter(GameObject enemy, Vector3 directionToCenter)
    {
        while (enemy != null)
        {
            enemy.transform.position += directionToCenter * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
