using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script for playing the success sound for the success function
public class Audioooo : MonoBehaviour
{
    // The audio clip for the success sound
    public AudioClip successSound;

    // A reference to the SkillCheck script on this game object
    private SkillCheck skillCheck;

    // Start is called before the first frame update
    void Start()
    {
        // Get the SkillCheck script from this game object
        skillCheck = GetComponent<SkillCheck>();

        // Add a listener to the onSuccess event that calls the PlaySuccessSound method
        skillCheck.onSuccess.AddListener(PlaySuccessSound);
    }

    // A method to play the success sound on this game object's audio source
    void PlaySuccessSound()
    {
        // Get the audio source component from this game object
        AudioSource audioSource = GetComponent<AudioSource>();

        // Play the success sound on this audio source
        audioSource.PlayOneShot(successSound);
    }
}
