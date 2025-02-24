using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    
    private int playerMask = 1 << 8;
    public bool shouldOpen;
    public bool roomComplete=false;
    [SerializeField] private GameObject enemySpawner;
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
        if(!roomComplete){
        if (Physics.Linecast(startPoint, endPoint, playerMask))
        {           
         shouldOpen = false;
            spawner.shouldSpawn = true;
        }
        }
        if(roomComplete){
            shouldOpen = true;
        }
    }
    void OnTriggerEnter (Collider other)
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
