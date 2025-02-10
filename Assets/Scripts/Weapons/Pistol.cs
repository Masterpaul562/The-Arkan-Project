using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    void Awake()
    {
        maxAmmo = 12;
        curentAmmo = 12;
    }
   protected override void Shoot()
    {
        curentAmmo--;
        if (curentAmmo<=0)
        {
            Reload();
        }
    }
    protected override void Reload()
    {
        curentAmmo = maxAmmo;
    }
}
