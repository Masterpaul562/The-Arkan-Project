using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Heavy : MonoBehaviour
{
   public Transform player;
   private int health;
   public GameObject door; 
   [SerializeField] private float speed; 
   [SerializeField] private float Rotspeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0){
            Destroy(this.gameObject);
            door.GetComponent<BossDoor>().roomDone = true;
        }
    }
}
