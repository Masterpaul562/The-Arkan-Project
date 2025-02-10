using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public int curentAmmo;
    public bool needReload;
    public void BaseShoot()
    {
        Shoot();
    }
    public void BaseReload()
    {
        Reload();
    }   
    protected virtual void Shoot()
    {

    }
    protected virtual void Reload()
    {

    }

}
