using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunViewManager : MonoBehaviour
{
    public GameObject playerGunBack;
    public GameObject playerGunFront;
    public GameObject playerGunR;
    public GameObject playerGunL;

    private Vector2 movementInput; 

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
}
