using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityObjectReplacer : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    // This function is called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player or part of the player (e.g., the VR camera or controller)
        // You might use tags or specific component checks to ensure the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Disable the first object
            if (objectToDisable != null)
                objectToDisable.SetActive(false);

            // Enable the second object
            if (objectToEnable != null)
                objectToEnable.SetActive(true);
        }
    }
}

