using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Heavy : MonoBehaviour
{
   public Transform player;  
   public GameObject door; 
   public Transform[] jumpLoc;
   [SerializeField] private float speed; 
   [SerializeField] private float Rotspeed;
    private Transform currentLoc;
    private int health;

    void Start()
    {
       currentLoc = jumpLoc[0];
    }

public enum MovementState {
    shooting,
    rotating, 
    jumping
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
