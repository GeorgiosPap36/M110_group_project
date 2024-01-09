using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_interaction_test : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 pos;

    public void TeleportPlayer()
    {
        playerTransform.localPosition = pos;
    }
}
