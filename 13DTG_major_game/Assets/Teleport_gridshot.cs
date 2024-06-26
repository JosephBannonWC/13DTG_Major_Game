using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_gridshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.position = new Vector3(-10.0f, 2f, -3.0f);
        }
    }
}
