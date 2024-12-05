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

    public DisablePlayerFunctions disablePlayerF; 

    void Start()
    {
       loadHealth();
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        health = 100;

        // in case theres no saved health yet
        if (!PlayerPrefs.HasKey("PlayerHealth"))
        {
            health = maxHealth;
            saveHealth(); 
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            playerDied();
        }
    }

    // call this anywhere to apply damage, just pass in the amount.
    public void applyDamage(int damage)
    {
        health -= damage;

        // if the damage goes beyond the health, just set the hp to a flat zero.
        if (health <= 0)
        {
            health = 0;
        }
        saveHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            applyDamage(projectileDamageTaken);
        }
        else if (collision.gameObject.CompareTag("BossProjectile"))
        {
            applyDamage(projectileDamageTaken * bossDamageMultiplier);
        }
        else if (collision.gameObject.CompareTag("Melee"))
        {
            applyDamage(meleeDamageTaken);
        }
        else if (collision.gameObject.CompareTag("BossMelee"))
        {
            applyDamage(meleeDamageTaken * bossDamageMultiplier);
        }
    }
    private void playerDied()
    {
        disablePlayerF.disablePlayerMechanics(health);
        Time.timeScale = 0f; 
    }
    public void saveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }

    public void loadHealth()
    {
        health = PlayerPrefs.GetInt("PlayerHealth", maxHealth); 
    }  
}
