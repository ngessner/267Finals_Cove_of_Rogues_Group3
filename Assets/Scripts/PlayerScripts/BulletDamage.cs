using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float destroyTime = 3f;

    void Start()
    {
        Destroy(gameObject, destroyTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // get enemy component
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.health -= 20;
                if (enemy.health <= 0)
                {
                    // destroy enemy
                    Destroy(collision.gameObject); 
                }
            }

            // check for boss component
            EnemyBossController boss = collision.GetComponent<EnemyBossController>();
            if (boss != null)
            {
                boss.bossHealth -= 20; 
                if (boss.bossHealth <= 0)
                {
                    // destroy boss
                    Destroy(collision.gameObject); 
                }
            }

            // bullet destroy for both scenarios
            Destroy(gameObject);
        }
    }
}
