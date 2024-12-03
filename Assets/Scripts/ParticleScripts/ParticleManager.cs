using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject[] particlePrefabs;
    public float normParticleDuration = 2f;

    public void createParticle(int i, Vector2 spawnPoint, float lifetime = -1f)
    {
        GameObject particle = Instantiate(particlePrefabs[i], spawnPoint, Quaternion.identity);

        float particleDuration;

        if (lifetime > 0f)
        {
            particleDuration = lifetime;
        }
        else
        {
            particleDuration = normParticleDuration;
        }

        Destroy(particle, particleDuration);
    }
}
