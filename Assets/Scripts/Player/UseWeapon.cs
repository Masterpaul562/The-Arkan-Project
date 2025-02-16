using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    public GameObject selected;
    public GameObject pistol;
    public GameObject rifle; 

    void Awake()
    {
        if (selected == null)
        {
            selected = pistol;
        }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected.SetActive(false);
            selected = pistol;
            selected.SetActive(true);
            selected.GetComponent<Pistol>().canFire = true;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            selected.SetActive(false);
            selected = rifle; 
            selected.SetActive(true);
            selected.GetComponent<Rifle>().canFire = true;
        }
        if (selected.GetComponent<Weapon>() != null) {
            var getWeapon = selected.GetComponent<Weapon>(); 
            if (Input.GetKeyDown(KeyCode.R))
            {
              if (getWeapon.curentAmmo != getWeapon.maxAmmo)
                {
                    getWeapon.BaseReload();
                }
            }
            if (selected == pistol)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selected.GetComponent<Weapon>().BaseShoot();
                }
            } else if (selected = rifle)
            {
                if (Input.GetMouseButton(0))
                {
                    selected.GetComponent<Weapon>().BaseShoot();
                }
            }
        }
    }
}
