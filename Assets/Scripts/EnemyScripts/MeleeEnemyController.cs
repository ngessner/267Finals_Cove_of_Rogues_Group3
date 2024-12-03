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
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        moveEnemy();
        updateAnim();
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
            Vector2 direction = (playerPos - (Vector2)transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

            animator.SetFloat("xInput", direction.x);
            animator.SetFloat("yInput", direction.y);
        }
        else
        {
            animator.SetFloat("xInput", 0);
            animator.SetFloat("yInput", 0);
        }
    }

    private void updateAnim()
    {
        Vector2 direction = playerPos - (Vector2)transform.position;

        animator.SetFloat("xInput", direction.x);
        animator.SetFloat("yInput", direction.y);
    }

    private void enemyAttack()
    {


        if (canAttack() && coolDownTimer())
        {
            
        }
    }
}
