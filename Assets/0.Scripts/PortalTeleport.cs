using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    private SceneTransitionManager transitionManager;

    void Start()
    {
        transitionManager = GameObject.Find("Transition Manager").GetComponent<SceneTransitionManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ASDASD");
            transitionManager.GoToScene(2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ASDASD");
            transitionManager.GoToScene(2);
        }
    }
}
