using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Heavy : MonoBehaviour
{
    public Transform player;
    private Transform target;
    public GameObject door;
    public Transform[] jumpLoc;
    [SerializeField] private float rotSpeed;
    private Transform currentLoc;
    private int health;
    public float angle;
    private bool shouldShoot;

    void Start()
    {
        currentLoc = jumpLoc[0];
        StartCoroutine(FOVRoutine());
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
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

        if (health < 0) {
            Destroy(this.gameObject);
            door.GetComponent<BossDoor>().roomDone = true;
        }
        Statehandler();
        if (state == MovementState.shooting)
        {

        } else if (state == MovementState.rotating)
        {
            target = player;
            Rotate();
        } else if (state == MovementState.jumping)
        {
            SelectRandLoc();
            Rotate();

        }
    }
    private void Statehandler()
    {
        if (shouldShoot)
        {
            state = MovementState.shooting;
            Debug.Log("Hooray");
        }else
        {
            state = MovementState.rotating;
        }
    }
    
    private void Rotate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
    }
    private void SelectRandLoc() {
        
        int i = Random.Range(0,5);
        target = jumpLoc[i];              
        currentLoc = target;
        Debug.Log(transform);      
    }
    private void FieldOfViewCheck()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, dir)<angle/2)
        {
            shouldShoot = true;
            
        } else
        {
            Debug.Log("Yippee");
            shouldShoot = false;   
        }
    }
}
