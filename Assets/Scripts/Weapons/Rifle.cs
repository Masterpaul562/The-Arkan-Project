using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    void Awake()
    {
        maxAmmo = 31;
        curentAmmo = 30;
    }
    protected override void Shoot()
    {
        curentAmmo--;
        if (curentAmmo <= 0)
        {
            Reload();
        }
    }
    protected override void Reload()
    {
        curentAmmo = maxAmmo - 1;
    }
}
