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
        private XRGripButton gripButton1;
        [SerializeField]
        private XRGripButton gripButton2;
        [SerializeField]
        private XRGripButton gripButton3;

        [SerializeField]
        private XRLever lever1;
        [SerializeField]
        private XRLever lever2;

        private int quiz2IntractionTimes = 0;

        private bool pressable = true;

        private string superposition = @"SUPERPOSITION:
    There is a red rose in the container on the table. Pick one of the following answers: 
    A.The rose is red, B.The rose is dried up, C.Both";
        private string entanglement = @"ENTANGLEMENT:
    The two levers are entangled, Move them to see how the behave.";
        private string readyText = "The exhibit is now ready!";

        void Update()
        {
            if (quiz2IntractionTimes >= 5)
            {
                screenText.text = readyText;
                openedCurtain.SetActive(true);
                closedCurtain.SetActive(false);
            }
        }

        //Buttons - levers
        public void StartQuizButtonPressed()
        {
            screenText.text = superposition;
            quiz1Objects.SetActive(true);
            startQuizObjects.SetActive(false);
        }

        public void q1B1Pressed()
        {
            if (pressable)
            {
                pressable = false;
                UpdateButtons(pressable);

                redRose.SetActive(false);
                driedRose.SetActive(true);
                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeMaterial(opaqueMaterial, 2f));
            }
        }

        public void q1B2Pressed()
        {
            if (pressable)
            {
                pressable = false;
                UpdateButtons(pressable);

                redRose.SetActive(true);
                driedRose.SetActive(false);
                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeMaterial(opaqueMaterial, 2f));
            }
        }

        public void q1B3Pressed()
        { //Solution
            if (pressable)
            {
                pressable = false;
                UpdateButtons(pressable);

                roseContainerGlass.material = transparentMaterial;
                StartCoroutine(changeFlower(0.25f));
                StartCoroutine(SolveQuiz1(3f));
            }
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

        /*--------------------*/
        IEnumerator changeMaterial(Material mat, float secs)
        {
            yield return new WaitForSeconds(secs);
            roseContainerGlass.material = mat;
            pressable = true;
            UpdateButtons(pressable);
        }

        IEnumerator SolveQuiz1(float secs)
        {
            pressable = false;
            yield return new WaitForSeconds(secs);
            screenText.text = entanglement;
            quiz2Objects.SetActive(true);
            quiz1Objects.SetActive(false);
        }

        IEnumerator changeFlower(float secs)
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

        private void UpdateButtons(bool b)
        {
            gripButton1.enabled = b;
            gripButton2.enabled = b;
            gripButton3.enabled = b;
        }
    }
}
