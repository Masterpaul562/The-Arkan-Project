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
    [SerializeField] private GameObject bullet;
    [SerializeField, Range(0, 30)] private float fireRate;
    [SerializeField, Range(0, 30)] private float bulletSpeed;
    [SerializeField] private Transform bulletSpawn;
    private bool canFire;
    Rigidbody rb;

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
            yield return timeToNextFire;
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
            float? angle = RotateSpawn();
            if (angle != null)
            {
                if (canFire)
                {
                    canFire = false;
                    Fire();
                }
            }
            
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
    float? RotateSpawn()
    {
        float? angle = CalculateAngle(true);

        if (angle != null)
        {

            bulletSpawn.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
        return angle;
    }
    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = target.transform.position - bulletSpawn.position;
        float y = targetDir.y;
        targetDir.y = 0f;
        float x = targetDir.magnitude;
        float gravity = 9.8f;
        float sSqr = bulletSpeed * bulletSpeed;
        float underSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underSqrRoot);
            float highAngle = sSqr * root;
            float lowAngle = sSqr - root;
            if (low)
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        else
            return null;
    }
    private void Fire()
    {
        GameObject projectile = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        projectile.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawn.forward;
    }
    
}
