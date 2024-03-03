using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySoundOnAttach : MonoBehaviour
{
    public AudioSource audioSource; // Drag your AudioSource here through the inspector

    private void OnEnable()
    {
        // Subscribe to the select entered event
        GetComponent<XRSocketInteractor>().selectEntered.AddListener(PlaySoundOnAttachEvent);
    }

    private void OnDisable()
    {
        // Unsubscribe to the select entered event
        GetComponent<XRSocketInteractor>().selectEntered.RemoveListener(PlaySoundOnAttachEvent);
    }

    private void PlaySoundOnAttachEvent(SelectEnterEventArgs arg)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // Play the sound
        }
    }
}
