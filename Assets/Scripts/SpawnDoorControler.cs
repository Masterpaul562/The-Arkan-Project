using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorControler : MonoBehaviour
{

    private int playerMask = 1 << 8;
    public bool shouldOpen;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject doorControler;
    Animator animator;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;



    void Awake()
    {
        shouldOpen = true;
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        
            var spawner = enemySpawner.GetComponent<Spawn_Enemy>();
        if (!doorControler.GetComponent<doorControler>().roomComplete)
        {

            if (Physics.Linecast(startPoint, endPoint, playerMask))
            {
                shouldOpen = false;
                spawner.shouldSpawn = true;
                doorControler.GetComponent<doorControler>().exitDoor1.GetComponent<NormalDoorControler>().shouldOpen = false;
                doorControler.GetComponent<doorControler>().exitDoor2.GetComponent<NormalDoorControler>().shouldOpen = false;
            }
        }
         if (doorControler.GetComponent<doorControler>().roomComplete)
        {
            shouldOpen = true;
            doorControler.GetComponent<doorControler>().shouldOpenExit = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (shouldOpen)
        {
            if (other.CompareTag("Player"))
            {
                animator.SetTrigger("Open");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Closed");
        }
    }
}