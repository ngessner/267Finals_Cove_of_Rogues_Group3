using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject spawner;

    void Start()
    {
        spawnEnemies();
    }

    private void spawnEnemies()
    {
        int variation = Random.Range(0, enemies.Length);
        GameObject spawnedVariation = enemies[variation];

        Instantiate(spawnedVariation);
        spawnedVariation.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);

    }
}
