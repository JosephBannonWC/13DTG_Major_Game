using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boxTarget : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform spawnArea; 
    [Range(0f, 100f)] public float spawnInterval = 2f;
    private int targetsShot = 0;
    private int maxTargets = 30;
    private GameObject currentTarget;

    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (targetsShot < maxTargets)
        {
            if (currentTarget == null)
            {
                Vector3 position = new Vector3(
                    Random.Range(spawnArea.position.x - 10f, spawnArea.position.x + 10f),
                    Random.Range(spawnArea.position.y, spawnArea.position.y + 0.01f),
                    Random.Range(spawnArea.position.z, spawnArea.position.z + 10f)
                );

                currentTarget = Instantiate(targetPrefab, position, Quaternion.identity);
                currentTarget.GetComponent<Target>().onDestroyed += OnTargetDestroyed;
            }

            yield return null;
        }

        Debug.Log("all targets shot");
    }

    void OnTargetDestroyed()
    {
        targetsShot++;
        currentTarget.GetComponent<Target>().onDestroyed -= OnTargetDestroyed;
        currentTarget = null;
    }
}
