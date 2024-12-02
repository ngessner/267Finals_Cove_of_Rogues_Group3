using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    // for lvl 1
    [SerializeField] private AudioClip sandWalkEffect; 
    // lvl 2
    [SerializeField] private AudioClip grassWalkEffect; 
    // lvl 3
    [SerializeField] private AudioClip woodWalkEffect; 

    private AudioSource audioSource;
    private string currentScene;
    public float VolumeAmt;
    private AudioClip currentFootstepClip;

    private bool isWalking = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = VolumeAmt;
        audioSource.loop = false; 

     // get current scene
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        SetFootstepClip();
    }

    void Update()
    {
        getMovement();
    }

    void SetFootstepClip()
    {
        // Assign the appropriate footstep sound based on the current scene
        if (currentScene == "PirateCampsLVL1")
        {
            currentFootstepClip = sandWalkEffect;
        }
        else if (currentScene == "RuinsLVL2")
        {
            currentFootstepClip = grassWalkEffect;
        }
        else if (currentScene == "DocksLVL3")
        {
            currentFootstepClip = woodWalkEffect;
        }
    }

    void getMovement()
    {     
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if ((moveHorizontal != 0 || moveVertical != 0) && !isWalking)
        {
            // if the player is moving and no sound is playing, play the footstep sound
            playFootstep();
        }
        else if (moveHorizontal == 0 && moveVertical == 0)
        {
            // walk state = false when no movement detected
            isWalking = false;
        }
    }

    void playFootstep()
    {
        if (currentFootstepClip != null)
        {
            audioSource.PlayOneShot(currentFootstepClip);
            isWalking = true;

            // delay the footstep sound because it was too fast at first
            Invoke(nameof(resetWalk), 0.3f); 
        }
    }

    void resetWalk()
    {
        isWalking = false;
    }
}