using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{

    private int playerMask = 1 << 8;
    public bool shouldOpen;
    [SerializeField] private GameObject enemySpawner;

    Animator animator;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    public bool roomDone;



    void Awake()
    {
        shouldOpen = true;
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        
            var spawner = enemySpawner.GetComponent<SpawnBoss>();
        
            if (!roomDone){
            if (Physics.Linecast(startPoint, endPoint, playerMask))
            {
                shouldOpen = false;
                spawner.shouldSpawn = true;
                
            }
            }
         if (roomDone)
        {
            shouldOpen = true;
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