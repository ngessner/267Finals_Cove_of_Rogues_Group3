using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionManager : MonoBehaviour
{
    public GameObject enemyViewBack;
    public GameObject enemyViewFront;
    public GameObject enemyViewRight;
    public GameObject enemyViewLeft;

    private GameObject player;
    private Vector2 directionToPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        UpdateEnemyView();
    }

    void UpdateEnemyView()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;

        enemyViewBack.SetActive(false);
        enemyViewFront.SetActive(false);
        enemyViewRight.SetActive(false);
        enemyViewLeft.SetActive(false);

        if (directionToPlayer.y > 0 && Mathf.Abs(directionToPlayer.y) > Mathf.Abs(directionToPlayer.x))
        {
            enemyViewBack.SetActive(true);
        }
        else if (directionToPlayer.y < 0 && Mathf.Abs(directionToPlayer.y) > Mathf.Abs(directionToPlayer.x))
        {
            enemyViewFront.SetActive(true);
        }
        else if (directionToPlayer.x > 0)
        {
            enemyViewRight.SetActive(true);
        }
        else if (directionToPlayer.x < 0)
        {
            enemyViewLeft.SetActive(true);
        }
    }
}
