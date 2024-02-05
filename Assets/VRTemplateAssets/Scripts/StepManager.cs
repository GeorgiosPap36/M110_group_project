using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        private TextMeshProUGUI m_StepButtonTextField;

        [SerializeField]
        private List<Step> m_StepList = new List<Step>();

        private int m_CurrentStepIndex = 0;

        public void Next()
        {
            ChangeStep(1);
        }

        public void Previous()
        {
            ChangeStep(-1);
        }

        private void ChangeStep(int stepChange)
        {
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex += stepChange;
            
            // Ensure m_CurrentStepIndex is within bounds
            if (m_CurrentStepIndex >= m_StepList.Count)
            {
                m_CurrentStepIndex = 0;
            }
            else if (m_CurrentStepIndex < 0)
            {
                m_CurrentStepIndex = m_StepList.Count - 1;
            }

            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}
