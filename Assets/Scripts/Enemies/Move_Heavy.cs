using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Heavy : MonoBehaviour
{
   public Transform player;  
   public GameObject door; 
   public Transform[] jumpLoc;
   [SerializeField] private float Rotspeed;
    private Transform currentLoc;
    private int health;

    void Start()
    {
       currentLoc = jumpLoc[0];
        Rotspeed = .5f;
    }
    public MovementState state;
    public enum MovementState
    {
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
        if (state == MovementState.shooting)
        {

        } else if (state == MovementState.rotating)
        {

        }else if (state == MovementState.jumping)
        {

        }
    }
    private void Rotate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * Rotspeed);
    }
}
