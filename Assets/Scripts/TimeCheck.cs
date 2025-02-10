using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
 
   public bool isDay;
    public float time; 
    void Start()
    {
        isDay = true;
    }
    void Update()
    {
        time = +Time.time;
       
        if(isDay&&time>60)
        {
            isDay = false; 
        }
        if (!isDay&&time > 120)
        {
            isDay = true;
            time = 0;
        }
       
    }
}
