using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Lobber : MonoBehaviour
{
    Rigidbody rb;
    public Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField,Range(0,10)]private float rotSpeed;
    [SerializeField, Range(0,30)] private float bulletSpeed;
    [SerializeField, Range(0, 30)] private float moveSpeed;
    [SerializeField, Range(0, 30)] private float fireRate;
    private bool canFire;
    private int health = 100;
    private int objMask = 1 << 11;
    public GameObject spawner;

    void Start() 
 {
    StartCoroutine(FireRateHandler());
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    float? RotateSpawn()
    {
        float? angle = CalculateAngle(true);

        if (angle != null)
        {
            
            bulletSpawn.localEulerAngles = new Vector3(360f - (float)angle,0f,0f);
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
        float underSqrRoot = (sSqr * sSqr) - gravity* (gravity * x* x + 2* y* sSqr);

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
    void Update()
    {
       
        if (health<= 0) {
Destroy(this.gameObject);
<<<<<<< HEAD
  //          spawner.GetComponent<Spawn_Enemy>().numOfEnemies -= 1;
=======
>>>>>>> parent of 7f03e75 (Hello)
        }
        Vector3 direction = (target.transform.position - transform.position).normalized;

        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float distancetoTarget = Vector3.Distance(transform.position, target.position);
        if (!Physics.Raycast(transform.position, directionToTarget, distancetoTarget, objMask))
        {
<<<<<<< HEAD
=======
            Debug.Log("HELO");
>>>>>>> parent of 7f03e75 (Hello)
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
            float? angle = RotateSpawn();
            if (angle != null)
            {
                if (canFire)
                {
                    canFire = false;
                    Fire();
                    StartCoroutine(FireRateHandler());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }
    private void Fire()
    {
        GameObject projectile = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        projectile.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawn.forward;
    }
    private IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1 / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
    void OnCollisionEnter(Collision collision) 
    {
if (collision.collider.tag == "Bullet") 
{
health -= 50;
}
    }
}
