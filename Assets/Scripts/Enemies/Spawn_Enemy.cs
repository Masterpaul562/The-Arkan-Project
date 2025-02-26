using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{

    [SerializeField] private GameObject pouncer;
    [SerializeField] private GameObject lobber;
    private GameObject selected; 
    [SerializeField]
    private Transform player;
    [SerializeField] private GameObject doorControler;
    public bool shouldSpawn;
    public int numOfEnemies = 0;
    public int numOfMaxEnemies;
    private Transform spawn1;
    private Transform spawn2;
    private Transform spawn3;
    

    void Start()
    {
        spawn1 = transform.GetChild(0);
        spawn2 = transform.GetChild(1);
        spawn3 = transform.GetChild(2);
    }
   
    void Update()
    {
<<<<<<< HEAD
        if (numOfEnemies >= 14)
        {
            shouldSpawn = false;
        }

        if (numOfEnemies == -1)
        {

            doorControler.GetComponent<SpawnDoorControler>().roomComplete = true;
        }
=======
>>>>>>> parent of 7f03e75 (Hello)
        if (shouldSpawn)
        {
            int offset = 0;
            for (int i = 0; i <= numOfMaxEnemies; i++)
            {

                numOfEnemies++;
                if (numOfEnemies <= 5)
                {

                    selected = pouncer;
                    var newEnemy = Instantiate(selected, new Vector3(spawn1.position.x, spawn1.position.y, spawn1.position.z + offset), spawn1.rotation);
                    newEnemy.GetComponent<Movement_Pouncer>().target = player;
                }
                else if (numOfEnemies >= 6 && numOfEnemies <= 10)
                {

                    var newEnemy = Instantiate(selected, new Vector3(spawn2.position.x, spawn2.position.y, spawn2.position.z + offset), spawn2.rotation);
                    newEnemy.GetComponent<Movement_Pouncer>().target = player;
                }
                else if (numOfEnemies >= 7 && numOfEnemies <= 15)
                {

                    selected = lobber;
                    var newEnemy = Instantiate(selected, new Vector3(spawn3.position.x + offset, spawn3.position.y, spawn3.position.z), spawn3.rotation);
                    newEnemy.GetComponent<Movement_Lobber>().target = player;
                }
                offset++;
                if (offset >= 5)
                {
                    offset = 0;
                }
            }
<<<<<<< HEAD
            numOfEnemies --;
=======

>>>>>>> parent of 7f03e75 (Hello)
        }
        
    }

}
