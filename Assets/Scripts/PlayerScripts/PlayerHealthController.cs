using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 200;

    public int projectileDamageTaken = 10;
    public int meleeDamageTaken = 15;
    public int bossDamageMultiplier = 2;

    //Code for health, damage, regaining health, and ending the game when health reaches zero.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            health -= projectileDamageTaken;
        }

        //I'm almost certain there is a way to figure out the enemy that spawned the projectile
        //If I find a way, this will change
        if(collision.gameObject.CompareTag("BossProjectile"))
        {
            health -= projectileDamageTaken * bossDamageMultiplier;
        }

        if(collision.gameObject.CompareTag("Melee"))
        {
            health -= meleeDamageTaken;
        }

        //same as above comments
        if(collision.gameObject.CompareTag("BossMelee"))
        {
            health -= meleeDamageTaken * bossDamageMultiplier;
        }
    }
}
