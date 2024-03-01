using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    [SerializeField]
    private AnimationClip openDoor;
    [SerializeField]
    private AnimationClip closeDoor;

    private Animator anim;

    [SerializeField]
    private bool isOpen;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DoorInteract()
    {
        if (isOpen)
            anim.Play(closeDoor.name);
        else
            anim.Play(openDoor.name);

        isOpen = !isOpen;
    }

}
