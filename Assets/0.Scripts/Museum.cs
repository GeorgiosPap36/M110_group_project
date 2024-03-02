using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityEngine.XR.Content.Interaction
{

    public class Museum : MonoBehaviour
    {

        [SerializeField]
        private TextMeshPro screenText;

        [SerializeField]
        private GameObject closedCurtain;
        [SerializeField]
        private GameObject openedCurtain;

        [SerializeField]
        private GameObject startQuizObjects;
        [SerializeField]
        private GameObject quiz1Objects;
        [SerializeField]
        private GameObject quiz2Objects;

        private bool pressable = true;

        [SerializeField]
        private MeshRenderer roseContainerGlass;
        [SerializeField]
        private GameObject redRose;
        [SerializeField]
        private GameObject driedRose;

        [SerializeField]
        private Material opaqueMaterial;
        [SerializeField]
        private Material transparentMaterial;



        [SerializeField]
        private bool q1B1;
        [SerializeField]
        private bool q1B2;
        [SerializeField]
        private bool q1B3;

        [SerializeField]
        private XRLever lever1;
        [SerializeField]
        private XRLever lever2;


        private int quiz2IntractionTimes = 0;


        private string superposition = @"SUPERPOSITION:
    There is a red rose in the container on the table. Pick one of the following answers: 
    A.The rose is red, B.The rose is dried up, C.Both";

        private string entanglement = @"ENTANGLEMENT:
    The two levers are entangled, Move them to see how the behave.";

        void Update()
        {
            Quiz1();

            if (quiz2IntractionTimes >= 5)
            {
                openedCurtain.SetActive(true);
                closedCurtain.SetActive(false);
            }
        }

        private void Quiz1()
        {
            if (q1B1)
            {
                redRose.SetActive(false);
                driedRose.SetActive(true);
                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeMaterial(opaqueMaterial, 3));
            }
            else if (q1B2)
            {
                redRose.SetActive(true);
                driedRose.SetActive(false);
                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeMaterial(opaqueMaterial, 3));
            }
            else if (q1B3)
            {
                //Solution
                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeFlower(1));
                StartCoroutine(SolveQuiz1(7));
            }
        }

        IEnumerator changeMaterial(Material mat, int secs)
        {
            pressable = false;
            yield return new WaitForSeconds(secs);
            roseContainerGlass.material = mat;
            pressable = true;
        }

        IEnumerator SolveQuiz1(int secs)
        {
            pressable = false;
            yield return new WaitForSeconds(secs);
            screenText.text = entanglement;
            quiz2Objects.SetActive(true);
            quiz1Objects.SetActive(false);
        }

        IEnumerator changeFlower(int secs)
        {
            while (quiz1Objects.activeInHierarchy)
            {
                redRose.SetActive(true);
                driedRose.SetActive(false);
                yield return new WaitForSeconds(secs);
                redRose.SetActive(false);
                driedRose.SetActive(true);
                yield return new WaitForSeconds(secs);
            }
        }

        public void StartQuizButtonPressed()
        {
            screenText.text = superposition;
            quiz1Objects.SetActive(true);
            startQuizObjects.SetActive(false);
        }

        public void q1B1Pressed()
        {
            if (pressable)
                q1B1 = true;
        }

        public void q1B1Released()
        {
            q1B1 = false;
        }

        public void q1B2Pressed()
        {
            if (pressable)
                q1B2 = true;
        }

        public void q1B2Released()
        {
            q1B2 = false;
        }

        public void q1B3Pressed()
        {
            if (pressable)
                q1B3 = true;
        }

        public void q1B3Released()
        {
            q1B3 = false;
        }

        public void LeverActivate1()
        {
            lever2.value = true;
            quiz2IntractionTimes++;
        }

        public void LeverDeactivate1()
        {
            lever2.value = false;
            quiz2IntractionTimes++;
        }

        public void LeverActivate2()
        {
            lever1.value = true;
            quiz2IntractionTimes++;
        }

        public void LeverDeactivate2()
        {
            lever1.value = false;
            quiz2IntractionTimes++;
        }
    }
}
