using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Lobber : MonoBehaviour
{
    public Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField,Range(0,10)]private float rotSpeed;
    [SerializeField, Range(0,30)] private float bulletSpeed;
    [SerializeField, Range(0, 30)] private float moveSpeed;
    [SerializeField, Range(0, 30)] private float fireRate;
    private bool canFire = true;

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
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
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
            this.transform.Translate(0,0, Time.deltaTime* moveSpeed);
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
}
