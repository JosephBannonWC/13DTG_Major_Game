using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    public float point;

  
    void Start()
    {
       
    }

 
    void Update()
    {
       
    }

   
    public void MinusPoint()
    {
        if (point > 0)
        {
            point -= 1;
            Debug.Log("Point -1: " + point);
        }
    }

    public void PlusPoint()
    {
        point += 1;
        Debug.Log("Point +1: " + point);
    }
}
