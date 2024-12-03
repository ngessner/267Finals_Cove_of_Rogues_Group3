using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public GameObject weaponHoldLocation;
    public GameObject bulletObj;
    public Transform currentFirePoint;
    public PlayerMovement playerMove;
    public GunViewManager gunView;

    public ParticleManager particle;

    //different depending on the weapon
    [SerializeField] private int weaponAmmo;
    [SerializeField] private int weaponMagSize;
    [SerializeField] private int weaponAmmoReserve;
    [SerializeField] private int weaponDamage;

    // firing weapons
    public float bulletSpeed;


    //Code for reloading, firing/using the weapon, ammo, and swapping between different weapons(?) 

    // Start is called before the first frame update
    void Start()
    {
        weaponAmmo = weaponMagSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && weaponAmmo < weaponMagSize && weaponAmmoReserve != 0)
        {
            reloadWeapon(weaponAmmo, weaponMagSize, weaponAmmoReserve);
        }

        if (Input.GetMouseButtonDown(0) && weaponAmmo > 0) 
        {
            fireWeapon();
            gunView.playGunParticles();
        }
    }

    private void fireWeapon()
    {
        currentFirePoint = playerMove.getCurrentFirepoint();

        GameObject bullet = Instantiate(bulletObj, currentFirePoint.position, currentFirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = currentFirePoint.up * bulletSpeed;
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
