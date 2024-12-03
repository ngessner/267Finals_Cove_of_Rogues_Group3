using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public GameObject weaponHoldLocation;
    public GameObject bulletObj;
    public Transform pointFromFired;

    //different depending on the weapon
    private int weaponAmmo;
    private int weaponMagSize;
    private int weaponAmmoReserve;
    private int weaponDamage;

    // firing weapons
    public float bulletSpeed;


    //Code for reloading, firing/using the weapon, ammo, and swapping between different weapons(?) 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && weaponAmmo < weaponMagSize && weaponAmmoReserve != 0)
        {
            reloadWeapon(weaponAmmo, weaponMagSize, weaponAmmoReserve);
        }

        fireWeapon();
    }

    private void fireWeapon()
    {
        GameObject bullet = Instantiate(bulletObj, pointFromFired.position, pointFromFired.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = pointFromFired.up * bulletSpeed;
        weaponAmmo--;

        Debug.Log("ammo: " + weaponAmmo);
    }


    private void reloadWeapon(int ammo, int magSize, int reserve)
    {
        for(int i = 0; i < magSize - ammo; i++)
        {
            reserve -= 1;

            ammo += 1;
        }
    }
}
