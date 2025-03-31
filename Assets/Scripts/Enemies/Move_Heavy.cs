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
    private bool shouldJump;
    [SerializeField] private GameObject bullet;
    [SerializeField, Range(0, 30)] private float fireRate;
    [SerializeField, Range(0, 30)] private float bulletSpeed;
    [SerializeField] private Transform bulletSpawn;
    private bool canFire;
    Rigidbody rb;
    private int timesFired = 0;
    [SerializeField] private int shotsTillJump;
    private bool choosingTarget;
    private bool facingWrongWay;
   
    

    void Start()
    {
        currentLoc = jumpLoc[0];
        StartCoroutine(FOVRoutine());
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        StartCoroutine(FireRateHandler());

    }
    private IEnumerator FireRateHandler()
    {
        float timeToNextFire = fireRate;
        WaitForSeconds wait = new WaitForSeconds(timeToNextFire);
        while (true)
        {
            yield return wait;
            canFire = true;
        }
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
    void Update()
    {
        
        if (health < 0) {
            Destroy(this.gameObject);
            door.GetComponent<BossDoor>().roomDone = true;
        }
        Statehandler();
        
        if (state == MovementState.shooting)
        {
            target = player;
            
            Rotate();             
            YRotateSpawn();
           
                if (canFire)
                {
                    canFire = false;
                     timesFired++;
                    StartCoroutine(Fire());
                }
            
            
        } else if (state == MovementState.rotating)
        {
            target = player;
            Rotate();
        } else if (state == MovementState.jumping)
        {           
            StartCoroutine(JumpCheck());           
            if (shouldJump) {
            shouldJump = false;       
            facingWrongWay = true;
            choosingTarget = true;       
            StartCoroutine(Jump());
            }
        }
    }
    private void Statehandler()
    {   if (timesFired >= shotsTillJump){
     
        state = MovementState.jumping; 
    }else
        if (shouldShoot && timesFired != shotsTillJump)
        {
            state = MovementState.shooting;
            
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
    private void YRotateSpawn() {
        bulletSpawn.transform.LookAt(target);
    }
    
    private void FieldOfViewCheck()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, dir)<angle/2)
        {
            shouldShoot = true;
            
        } else
        {
            
            shouldShoot = false;   
        }
    }
    
    
    
     private IEnumerator Fire()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        for (int i = 0; i<=3; i++) {
        
        yield return wait; 
        GameObject projectile = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        projectile.GetComponent<Rigidbody>().useGravity = false; 
        projectile.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawn.forward * 2;
       
        }
    }
    private IEnumerator Jump() {
        while (choosingTarget) {
            var i = Random.Range(0,5);
            target = jumpLoc[i];
            if (target != currentLoc) {
                choosingTarget = false;
            }
            yield return null; 
        }   
        while (facingWrongWay) {
            Rotate();
            

        }   
        yield return new WaitForSeconds(3);


    }
    private IEnumerator JumpCheck() {
        yield return new WaitForSeconds (3);
        shouldJump = true;
    }
}
