using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Content.Interaction
{
    public class ProjectileCount : MonoBehaviour
    {
        [SerializeField]
        private GameObject portal;

        [SerializeField]
        private int counter = 0;

        void Update()
        {
            if (counter >= 15)
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
            }
        }
    }
}