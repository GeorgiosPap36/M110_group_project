using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Content.Interaction {

    public class LevelManager : MonoBehaviour
    {

        [SerializeField]
        private XRLever l1c1, l2c1, l3c1, l1c2, l2c2, l3c2;

        [SerializeField]
        private GameObject door;

        void Update()
        {
            l3c2.value = l1c1.value;
            l1c2.value = l3c1.value;
            l2c1.value = l2c2.value;

            openDoor();
            solvePuzzle();
        }

        void openDoor()
        {
            if (door.activeInHierarchy)
            {
                if (l1c1.value && l3c1.value)
                {
                    door.SetActive(false);
                }
            }
        }

        void solvePuzzle()
        {
            if (l1c1.value && l2c2.value && !l3c1.value)
                Debug.Log("SOLVED");
        }
    }
}
