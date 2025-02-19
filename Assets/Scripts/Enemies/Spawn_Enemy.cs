using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject pouncer;
    [SerializeField]
    private GameObject lobber;
    private GameObject selected; 
    [SerializeField]
    private Transform player;
    [SerializeField, Range(0, 30)] private float spawnRate;
    private bool shouldSpawn; 
    private float time;  
    void Start() {
        StartCoroutine(spawnHandler());
    }
    void Update()
    {
 
        if (shouldSpawn)
        {
            
            shouldSpawn = false;
           int enemyNum = Random.Range(1,3);
           if (enemyNum == 1){
            selected = pouncer;
           } else if (enemyNum == 2) {
            selected = lobber;
           } 
            var newEnemy = Instantiate(selected, new Vector3(Random.Range(1,20), 1, Random.Range(1,20)), transform.rotation);
            if (selected == pouncer){
            newEnemy.AddComponent<Movement_Pouncer>();
            newEnemy.GetComponent<Movement_Pouncer>().target = player;
            } else if (selected == lobber) 
            {
                newEnemy.GetComponent<Movement_Lobber>().target = player;
            }
            StartCoroutine(spawnHandler());
        }
    }
    private IEnumerator spawnHandler()
    {
float timeToNextSpawn = spawnRate;
yield return new WaitForSeconds(timeToNextSpawn);
shouldSpawn = true; 
    }
}
