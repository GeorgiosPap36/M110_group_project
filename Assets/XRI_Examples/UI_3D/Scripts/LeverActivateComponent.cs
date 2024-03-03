using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit; 

public class LeverActivateComponent : MonoBehaviour
{
    [Tooltip("Reference to the XR Lever component on this GameObject")]
    public XRLever XRLever;

    [Tooltip("The target GameObject whose component you want to activate/deactivate")]
    public GameObject targetObject;

    [Tooltip("The type name of the component to activate/deactivate")]
    public string componentNameToToggle;

    private void Awake()
    {
        // Optionally ensure that the referenced objects and names are correct
        if (XRLever == null)
        {
            Debug.LogError("LeverActivateComponent: No XRLever component assigned.");
        }

        if (targetObject == null)
        {
            Debug.LogError("LeverActivateComponent: No target GameObject assigned.");
        }

        if (string.IsNullOrEmpty(componentNameToToggle))
        {
            Debug.LogError("LeverActivateComponent: No component name set to toggle.");
        }

        // Subscribe to the lever events
        if (XRLever != null)
        {
            XRLever.onLeverActivate.AddListener(ToggleComponentOn);
            XRLever.onLeverDeactivate.AddListener(ToggleComponentOff);
        }
    }

    private void ToggleComponentOn()
    {
        ToggleComponent(true);
    }

    private void ToggleComponentOff()
    {
        ToggleComponent(false);
    }

    private void ToggleComponent(bool state)
    {
        if (targetObject != null && !string.IsNullOrEmpty(componentNameToToggle))
        {
            Component componentToToggle = targetObject.GetComponent(componentNameToToggle);
            
            if (componentToToggle is Behaviour behaviour)
            {
                // Now you can safely set the enabled state
                behaviour.enabled = state;
            }
            else
            {
                Debug.LogError("LeverActivateComponent: The specified component is not a Behaviour and cannot be enabled/disabled.");
            }
        }
    }
}
