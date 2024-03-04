using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip brokenPortalAudio;

    [SerializeField]
    private bool audioPlayed;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = brokenPortalAudio;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!audioPlayed)
        {
            if (other.tag == "Player")
            {
                audioPlayed = true;
                audioSource.Play();
            }
        }
    }
}
