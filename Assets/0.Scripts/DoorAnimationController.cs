using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    [SerializeField]
    private AnimationClip openDoor;
    [SerializeField]
    private AnimationClip closeDoor;

    private Animator doorAnim;

    [SerializeField]
    private bool isOpen;

    [SerializeField] private AudioClip _doorSound;

    private AudioSource _audioSource;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
        isOpen = false;
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.clip = _doorSound;
        }
    }

    public void DoorInteract()
    {
        if (isOpen)
        {
            doorAnim.Play(closeDoor.name);
        }
        else
        {
            // _audioSource.clip = _doorSound;
            _audioSource.Play();
            // _audioSource.PlayClipAtPoint(_doorSound);
            doorAnim.Play(openDoor.name);
        }

        isOpen = !isOpen;
    }


}
