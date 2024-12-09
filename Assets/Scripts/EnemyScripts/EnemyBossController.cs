using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossController : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunLocation;
    public int bossHealth;
    public float moveSpeed;
    public float weaponRange;
    public float fireRate;

    private Animator animator;

    private GameObject player;
    private Vector2 playerPos;
    private float weaponCooldown;
    private int bossStage;



    void Start()
    {
        bossStage = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>(); 

    }


    void Update()
    {
        playerPos = player.transform.position;
        moveEnemy();
        enemyAttack();
    }

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

            Instantiate(bullet, gunLocation.position, gunLocation.transform.rotation);
            weaponCooldown = fireRate;
        }
    }

    private void moveEnemy()
    {
        if (!canShoot())
        {
            Vector2 direction = (playerPos - (Vector2)transform.position).normalized;

            // for blend tree
            animator.SetFloat("xInput", direction.x);
            animator.SetFloat("yInput", direction.y);

            transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
    }


    private void fightStages()
    {

        float newFireRate;
 
        newFireRate = (float)(fireRate * 0.75);

        if (bossHealth <= 200 * .75 && bossStage < 1)
        {
            bossStage = 1;
            fireRate = newFireRate;

        }
        else if(bossHealth <= 200 *.50 && bossStage < 2)
        {
            fireRate = newFireRate;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            bossHealth -= 20;
            fightStages();
        }
        // destroy the bullet on hit
        Destroy(collision.gameObject);
    }
}
