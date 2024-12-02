using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    private AudioSource audioSource;
    public float volumeAmt;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = backgroundMusic; 
        // loops 
        audioSource.loop = true; 
        // plays on awake for audio source
        audioSource.playOnAwake = true; 
        // volume adjuster
        audioSource.volume = volumeAmt; 

        if (backgroundMusic != null)
        {
            audioSource.Play();
        }
    }
}
