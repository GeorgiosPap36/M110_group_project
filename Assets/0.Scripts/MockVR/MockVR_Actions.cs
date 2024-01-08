using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockVR_Actions : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;


    public void Select()
    {
        playerTransform.localPosition = new Vector3(-10, 5, -10);
    }
}
