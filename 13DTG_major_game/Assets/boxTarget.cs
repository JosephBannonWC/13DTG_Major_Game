using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class boxTarget : MonoBehaviour


{
    
    // Start is called before the first frame update
   
    public GameObject projectile;
    [Range(0f, 100f)] public float Seconds = 10;
    public Transform TransformTarget;

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
    void Start()
    {
       
        StartCoroutine(wait());

        
    }
    IEnumerator wait()
    {
        while (true)
        {
        var position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(0, 10.0f), 0);
        GameObject clone = Instantiate(projectile, position, Quaternion.identity);
        yield return new WaitForSeconds(Seconds);
        Destroy(clone, 0.5f);

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
