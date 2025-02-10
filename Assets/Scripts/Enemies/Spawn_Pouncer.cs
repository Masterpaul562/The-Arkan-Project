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
    void Update()
    {
        if (shouldSpawn)
        {
            shouldSpawn = false;
            var newPouncer = Instantiate(pouncer, transform.position, transform.rotation);
            newPouncer.AddComponent<Movement_Pouncer>();
            newPouncer.GetComponent<Movement_Pouncer>().target = player;
            //newPouncer.GetComponent<Movement_Pouncer>().whatIsGround = Ground;
        }
    }
}
