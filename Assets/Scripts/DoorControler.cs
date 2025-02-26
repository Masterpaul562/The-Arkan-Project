using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControler : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject spawnDoor;
    public GameObject exitDoor1;
    public GameObject exitDoor2;
    public bool shouldOpenExit;
=======
=======
>>>>>>> parent of 7f03e75 (Hello)
    public int enemiesRemaining;
    private int playerMask = 1 << 8;
    public bool shouldOpen;
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
        if (Physics.Linecast(startPoint, endPoint, playerMask))
        {           
         shouldOpen = false;
            spawner.shouldSpawn = true;
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
>>>>>>> parent of 7f03e75 (Hello)
}
