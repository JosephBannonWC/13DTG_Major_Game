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
            col.transform.position = new Vector3(-90.2095871f, 3.23681736f, -53.5966911f);
        }
    }
}
