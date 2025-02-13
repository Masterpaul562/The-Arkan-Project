using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bullet;
    public Transform spawn;
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
   protected override void Shoot()
    {
        
        if (curentAmmo > 0 && curentAmmo>0)
        {
            var newBullet = Instantiate(bullet, spawn.position, spawn.rotation);
            newBullet.GetComponent<Rigidbody>().freezeRotation = true;
            newBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 30,ForceMode.Impulse);
            curentAmmo = curentAmmo - 1;
            muzzleflash.Play();
            audioSource.clip = revGunshot;
            audioSource.Play();

        }
        
        if (curentAmmo<=0)
        {
            Invoke(nameof(Reload),3);
        }
    }
    protected override void Reload()
    {
        curentAmmo = maxAmmo;
    }
}
