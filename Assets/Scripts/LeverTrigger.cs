using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure to include the namespace if your XRLever is within one
using UnityEngine.XR.Content.Interaction;

public class LeverTrigger : MonoBehaviour
{
    // Reference to the XRLever component on Lever (1)
    public XRLever leverToActivate;

    public void TriggerLever()
    {
        // Check if the referenced lever is not null
        if (leverToActivate != null)
        {
            // Set the value to true to activate the lever
            leverToActivate.value = true;
        }
        else
        {
            Debug.LogError("No XRLever component assigned to LeverTrigger.");
        }
    }
}

