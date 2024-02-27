using UnityEngine;
using System.Collections;

public class DelayedAudioPlay : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public float delay = 2.9f; // Delay in seconds before the sound starts playing

    void Start()
    {
        // Start the coroutine that handles the delayed audio play
        StartCoroutine(PlaySoundAfterDelay());
    }

    IEnumerator PlaySoundAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Enable the AudioSource and play the sound
        audioSource.enabled = true;
        audioSource.Play();
    }
}
