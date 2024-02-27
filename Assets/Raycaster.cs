using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Camera vrCamera;
    public LayerMask targetLayers;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayers))
        {
            // This will only hit objects on the layers specified in targetLayers
            Debug.Log("Hit " + hit.collider.gameObject.name);
            // You can then check if the hit object is a button, lever, etc., and handle the interaction accordingly
        }
    }
}
