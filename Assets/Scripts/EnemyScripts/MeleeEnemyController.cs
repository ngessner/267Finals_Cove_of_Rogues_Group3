using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public GameObject sword;
    public float moveSpeed;
    public float attackRange;
    public float attackSpeed;

    private GameObject player;
    private Vector2 playerPos;
    private float weaponCooldown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        moveEnemy();
        flipSprite();
    }


    private bool canAttack()
    {
        float distance = Vector2.Distance(transform.position, playerPos);

        if (distance <= attackRange)
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

    private void moveEnemy()
    {
        if (!canAttack())
        {
            Vector2 playerPos = player.transform.position;

            transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
    }

    private void flipSprite()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0,0, 0);
        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void enemyAttack()
    {


        if (canAttack() && coolDownTimer())
        {
            
        }
    }
}
