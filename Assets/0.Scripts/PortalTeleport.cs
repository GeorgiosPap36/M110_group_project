using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    private SceneTransitionManager transitionManager;

    [SerializeField]
    private int sceneNumberToLoad = 2;

    void Start()
    {
        transitionManager = GameObject.Find("Transition Manager").GetComponent<SceneTransitionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transitionManager.GoToScene(sceneNumberToLoad);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transitionManager.GoToScene(sceneNumberToLoad);
        }
    }
}
