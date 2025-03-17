using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
   public bool shouldSpawn; 
   private bool hasSpawned = true; 
   public bool bossAlive;
   [SerializeField] private GameObject boss;
   [SerializeField] private GameObject door;
   [SerializeField] private Transform spawnLoc; 
    [SerializeField] private Transform player; 
   
   



    // Update is called once per frame
    void Update()
    {
        if(shouldSpawn && hasSpawned){
            hasSpawned = false; 
           var Boss =  Instantiate(boss, spawnLoc.position,spawnLoc.rotation);
           Boss.GetComponent<Move_Heavy>().door = door;
           Boss.GetComponent<Move_Heavy>().player = player; 
           Boss.GetComponent<Move_Heavy>().jumpLoc = new Transform[5];
           door.GetComponent<BossDoor>().roomDone = false; 
           for (int i=0;i<5;i++) {
Boss.GetComponent<Move_Heavy>().jumpLoc[i] = transform.GetChild(i);
           }
        }
    }
}
