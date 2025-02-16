using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bullet;
    [SerializeField] private GameObject player;
    public Transform spawn;
    public float fireRate;
    public bool canFire = true;
    private bool canReload= false;
    [SerializeField]
    private float reloadTime; 
    [SerializeField]
    private ParticleSystem muzzleflash;
    [SerializeField] private AudioClip revGunshot;
    private AudioSource audioSource;
    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        maxAmmo = 12;
        curentAmmo = 12;
    }
    private void Update()
    {
        if (curentAmmo <= 0 && canReload == false)
        {
            StartCoroutine(ReloadHandler());
        }
        if (canReload)
        {
            canReload = false;
            Reload();
        }
    }
   protected override void Shoot()
    {   
        
            if (curentAmmo > 0  && canFire)
            {
                canFire = false;
                var newBullet = Instantiate(bullet, spawn.position, spawn.rotation);
                newBullet.GetComponent<Rigidbody>().freezeRotation = true;
                newBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 30, ForceMode.Impulse);
                curentAmmo = curentAmmo - 1;
                muzzleflash.Play();
                audioSource.clip = revGunshot;
                audioSource.Play();
                StartCoroutine(FireRateHandler());

            }
              
    }
    protected override void Reload()
    {
        curentAmmo = maxAmmo;
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
