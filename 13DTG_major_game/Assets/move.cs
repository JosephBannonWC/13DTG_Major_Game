using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class move : MonoBehaviour
{
public GameObject cubePrefab;

void Update()
{
        
        
    
}
    private void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
        Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
    }
}

