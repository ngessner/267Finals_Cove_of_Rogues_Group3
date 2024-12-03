using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunLocation;
    public float moveSpeed;
    public float weaponRange;
    public float fireRate;
    public float bulletLife;
    
    
    private float weaponCooldown;
    private GameObject player;
    private Vector2 playerPos;
   


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerPos = player.transform.position;
        moveEnemy();
        enemyAttack();
    }

    //check to see if enemy is in range to shoot
    private bool canShoot()
    {
        Vector2 enemyPos = transform.position;

        float distance = Vector2.Distance(enemyPos, playerPos);

        if (distance <= weaponRange) 
        {
            return true;
        }

        return false;
    }

    private bool coolDownTimer()
    {
        if (weaponCooldown <= 0)
        {
            return true;
        }
        else 
        {
            weaponCooldown -= Time.deltaTime;
            return false;
        }
    }

    private void enemyAttack()
    {
        Vector2 gunDirection = (playerPos - (Vector2)gunLocation.transform.position).normalized;
        gunLocation.transform.right = gunDirection;

        if (canShoot() && coolDownTimer())
        {

            Instantiate(bullet,gunLocation.position, gunLocation.transform.rotation);
            weaponCooldown = fireRate;
        }
    }

    //move enemy into attack range 
    private void moveEnemy()
    {
        if (!canShoot())
        {
            Vector2 playerPos = player.transform.position;

            transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
    }
}
