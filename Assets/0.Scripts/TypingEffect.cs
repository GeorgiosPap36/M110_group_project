using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using System.Collections;

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f; // Time between each character
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        textComponent.text = ""; // Start with an empty text
    }

    public void StartTypingEffect(string textToType)
    {
        StartCoroutine(TypeText(textToType));
    }

    IEnumerator TypeText(string textToType)
    {
        textComponent.text = ""; // Reset text to empty
        foreach (char letter in textToType.ToCharArray())
        {
            textComponent.text += letter; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Wait a bit before adding the next character
        }
    }
}