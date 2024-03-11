using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Content.Interaction {

    public class LeverManager : MonoBehaviour
    {

        [SerializeField]
        private XRLever l1c1, l2c1, l3c1, l1c2, l2c2, l3c2;

        [SerializeField]
        private DoorAnimationController doorController;

        [SerializeField]
        private GameObject portalBlue;

        [SerializeField]
        private Material defaultLeverMaterial;
        [SerializeField]
        private Material highlightMaterial;

        [SerializeField]
        private float timeForHint;

        private bool doorInteracted = false;
        private bool portalInteracted = false;
        private bool timeHasPassed = false;

        void Update()
        {
            l3c2.value = l1c1.value;
            l1c2.value = l3c1.value;
            l2c1.value = l2c2.value;

            if (!doorInteracted)
            {
                openDoor();
            }

            if (!portalInteracted || timeHasPassed)
            {
                highlitghtLevers();
            }

            solvePuzzle();
        }

        void openDoor()
        {
            // if (door.activeInHierarchy)
            if (doorController)
            {
                if (l1c1.value && l3c1.value)
                {
                    Debug.Log("INSIDE");
                    // door.SetActive(false);
                    doorController.DoorInteract();
                    doorInteracted = true;
                    StartCoroutine(waitToGiveHint(timeForHint));
                }
            }
        }

        void solvePuzzle()
        {
            if (l1c1.value && l2c2.value && !l3c1.value)
            {
                Debug.Log("SOLVED");
                if (portalBlue != null && !portalBlue.activeSelf)
                {
                    portalBlue.SetActive(true);
                    portalInteracted = true;
                }
            }
        }

        void highlitghtLevers()
        {
            if (timeHasPassed)
            {
                leverValueCheck(l1c1, true);
                leverValueCheck(l2c2, true);
                leverValueCheck(l3c1, false);
            }
        }

        private void leverValueCheck(XRLever lever, bool value)
        {
            if (lever.value == value)
            {
                lever.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = defaultLeverMaterial;
            }
            else
            {
                lever.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = highlightMaterial;
            }
        }

        private IEnumerator waitToGiveHint(float secs)
        {
            yield return new WaitForSeconds(secs);
            timeHasPassed = true;
        }
    }
}
