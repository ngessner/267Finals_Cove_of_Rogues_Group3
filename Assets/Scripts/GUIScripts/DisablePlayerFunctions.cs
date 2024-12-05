using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerFunctions : MonoBehaviour
{
    public GameObject playerUI; 
    public GameObject deathUI; 
    public PlayerMovement pMovementScript; 
    public PlayerWeaponHandler pWeaponHandler; 
    public GunViewManager gunViewManager;

    private void Start()
    {
        if (deathUI != null)
        {
            deathUI.SetActive(false);
        }
    }

    public void disablePlayerMechanics(int health)
    {
        if (health <= 0)
        {
            if (playerUI != null)
            {
                playerUI.SetActive(false);
            }

            if (pMovementScript != null)
            {
                pMovementScript.enabled = false;
            }
            if (pWeaponHandler != null)
            {
                pWeaponHandler.enabled = false;
            }
            if (gunViewManager != null)
            {
                gunViewManager.enabled = false;
            }
            enableDeathScreen();
        }
    }
    private void enableDeathScreen()
    {
        if (deathUI != null)
        {
            deathUI.SetActive(true);
        }
    }
}
