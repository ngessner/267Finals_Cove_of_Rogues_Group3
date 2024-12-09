using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public GameObject sword;
    public float moveSpeed;
    public float attackRange;
    public float attackSpeed;
    public int attackDamage = 50;
    public int health;

    private GameObject player;
    private Vector2 playerPos;
    private float weaponCooldown;
    public Animator animator;

    private PlayerHealthController playerHealthController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthController = player.GetComponent<PlayerHealthController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        moveEnemy();
        updateAnim();

        if (canAttack() && coolDownTimer())
        {
            enemyAttack();
        }
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
            animator.SetBool("attacking", false);
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
        if (playerHealthController != null)
        {
            animator.SetBool("attacking", true);
            playerHealthController.applyDamage(attackDamage);
            // cooldown reset
            weaponCooldown = attackSpeed; 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 20;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
