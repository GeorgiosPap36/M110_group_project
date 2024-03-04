using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityEngine.XR.Content.Interaction
{
    public class ProjectileCount : MonoBehaviour
    {
        [SerializeField]
        private GameObject portal;

        [SerializeField]
        private TextMeshPro tmpText;

        [SerializeField]
        private int maxCounter;
        [SerializeField]
        private int counter = 0;

        void Update()
        {
            if (counter >= maxCounter)
            {
                portal.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Projectile")
            {
                other.GetComponent<DestroyObject>().shouldBeDestroyed = false;
                counter++;
                tmpText.text = counter + "/15";
            }
        }
    }
}