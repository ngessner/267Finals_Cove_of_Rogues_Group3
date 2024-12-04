using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    public Image healthBar; 
    private PlayerHealthController healthController; 
    public float health; 

    void Start()
    {
        GameObject healthObj = GameObject.FindGameObjectWithTag("Player");
        healthController = healthObj.GetComponent<PlayerHealthController>();

        updateHealthBar();
    }

    void Update()
    {
        health = healthController.health;
        updateHealthBar();
    }

    void updateHealthBar()
    {
        healthBar.fillAmount = health / healthController.maxHealth;
    }
}
