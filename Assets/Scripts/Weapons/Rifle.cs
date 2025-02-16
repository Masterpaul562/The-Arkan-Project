using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public bool canFire = true;
    public bool canReload;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawn;
    [SerializeField] private ParticleSystem muzzleflash;
    [SerializeField] private AudioClip rifleGunshot;
    [SerializeField, Range(0, 10)] private float reloadTime;
    [SerializeField, Range(0, 10)] private float fireRate;
    private AudioSource audioSource;
     
    
    void Awake()
    {
        canFire = true;
        maxAmmo = 31;
        curentAmmo = 30;
    }
    private void Update()
    {
        if (curentAmmo <= 0 && canReload == false)
        {
            StartCoroutine(ReloadHandler());
        }
        if (canReload && curentAmmo != maxAmmo)
        {
            canReload = false;
            Reload();
        }
    }
    protected override void Shoot()
    {
        if (canFire && curentAmmo > 0)
        {
            canFire = false;
            var newBullet = Instantiate(bullet, spawn.position, spawn.rotation);
            newBullet.GetComponent<Rigidbody>().freezeRotation = true;
            newBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 60, ForceMode.Impulse);
            muzzleflash.Play();
            curentAmmo--;
            StartCoroutine(FireRateHandler());
        }
        
    }
    protected override void Reload()
    {
        curentAmmo = maxAmmo - 1;
    }
    private IEnumerator ReloadHandler()
    {

        yield return new WaitForSeconds(reloadTime);
        canReload = true;

    }
    private IEnumerator FireRateHandler()
    {
        float timeToNextFire = 1 / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }
}
