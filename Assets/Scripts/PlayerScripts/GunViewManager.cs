using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunViewManager : MonoBehaviour
{
    public GameObject playerGunBack;
    public GameObject playerGunFront;
    public GameObject playerGunR;
    public GameObject playerGunL;

    public ParticleManager particle;

    private Vector2 movementInput;

    // Offsets for particles based on direction
    public Vector2 offsetBack = new Vector2(0, 1);
    public Vector2 offsetFront = new Vector2(0, -1);
    public Vector2 offsetRight = new Vector2(1, 0);
    public Vector2 offsetLeft = new Vector2(-1, 0);

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        updateGunDirection();
    }

    void updateGunDirection()
    {
        playerGunBack.SetActive(false);
        playerGunFront.SetActive(false);
        playerGunR.SetActive(false);
        playerGunL.SetActive(false);

        if (movementInput.y == -1 && movementInput.x == -1)
        {
            playerGunL.SetActive(true);
        }
        else if (movementInput.y == -1 && movementInput.x == 1)
        {
            playerGunR.SetActive(true);
        }
        else if (movementInput.y == 1 && movementInput.x == -1)
        {
            playerGunL.SetActive(true);
        }
        else if (movementInput.y == 1 && movementInput.x == 1)
        {
            playerGunR.SetActive(true);
        }
        else if (movementInput.y > 0)
        {
            playerGunBack.SetActive(true);
        }
        else if (movementInput.y < 0)
        {
            playerGunFront.SetActive(true);
        }
        else if (movementInput.x > 0)
        {
            playerGunR.SetActive(true);
        }
        else if (movementInput.x < 0)
        {
            playerGunL.SetActive(true);
        }
    }

    public void playGunParticles()
    {
        Vector2 spawnPosition = Vector2.zero;
        Transform firePoint = null;

        if (movementInput.y == -1 && movementInput.x == -1)
        {
            firePoint = playerGunL.transform;
            spawnPosition = (Vector2)firePoint.position + offsetLeft;
        }
        else if (movementInput.y == -1 && movementInput.x == 1)
        {
            firePoint = playerGunR.transform;
            spawnPosition = (Vector2)firePoint.position + offsetRight;
        }
        else if (movementInput.y == 1 && movementInput.x == -1)
        {
            firePoint = playerGunL.transform;
            spawnPosition = (Vector2)firePoint.position + offsetLeft;
        }
        else if (movementInput.y == 1 && movementInput.x == 1)
        {
            firePoint = playerGunR.transform;
            spawnPosition = (Vector2)firePoint.position + offsetRight;
        }
        else if (movementInput.y > 0)
        {
            firePoint = playerGunBack.transform;
            spawnPosition = (Vector2)firePoint.position + offsetBack;
        }
        else if (movementInput.y < 0)
        {
            firePoint = playerGunFront.transform;
            spawnPosition = (Vector2)firePoint.position + offsetFront;
        }
        else if (movementInput.x > 0)
        {
            firePoint = playerGunR.transform;
            spawnPosition = (Vector2)firePoint.position + offsetRight;
        }
        else if (movementInput.x < 0)
        {
            firePoint = playerGunL.transform;
            spawnPosition = (Vector2)firePoint.position + offsetLeft;
        }

        particle.createParticle(0, spawnPosition, 0.30f);
    }
}
