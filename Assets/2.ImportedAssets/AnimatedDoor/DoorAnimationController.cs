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
        Debug.Log("ASDASD");
        if (isOpen)
            doorAnim.Play(closeDoor.name);
        else
            _audioSource.Play();
            doorAnim.Play(openDoor.name);

        isOpen = !isOpen;
    }
}
