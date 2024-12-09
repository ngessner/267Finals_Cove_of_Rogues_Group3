using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatHandler : MonoBehaviour
{
    public EnemyBossController bossController;
    public DisablePlayerFunctions playerFunctions; 
    public GameObject winUI; 
    public GameObject deathUI; 

    private bool bossDefeated = false;

    private void Start()
    {
        if (winUI != null)
        {
            winUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (!bossDefeated && bossController != null && bossController.bossHealth <= 0)
        {
            bossDefeatManager();
        }
    }

    private void bossDefeatManager()
    {
        bossDefeated = true;

        if (playerFunctions != null)
        {
            // pass health = zero simulate player death mechanics but with boss pretty much
            playerFunctions.disablePlayerMechanics(0); 
        }

        if (winUI != null)
        {
            winUI.SetActive(true);
        }

        if (deathUI != null)
        {
            deathUI.SetActive(false);
        }
    }
}
