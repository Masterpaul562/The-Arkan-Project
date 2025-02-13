using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Pouncer : MonoBehaviour
{
    [SerializeField]
    private GameObject pouncer;
    [SerializeField]
    private Transform player;
    private bool shouldSpawn = true; 
    private float time;  
    void Update()
    {
 time += Time.deltaTime; 
 time %= 2f; 
 if (time>=2)
  {
shouldSpawn = true;
  }
        if (shouldSpawn)
        {
            time = 0;
            shouldSpawn = false;
            var newPouncer = Instantiate(pouncer, transform.position, transform.rotation);
            newPouncer.AddComponent<Movement_Pouncer>();
            newPouncer.GetComponent<Movement_Pouncer>().target = player;
        }
    }
}
