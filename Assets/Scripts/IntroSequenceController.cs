using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequenceController : MonoBehaviour
{
    public Animator gameTitleAnimator; // Assign in inspector
    public Animator gameMenuUIAnimator; // Assign in inspector
    public float delayBeforeMenuFade = 0f; // Additional delay if needed

    private void Start()
    {
        // Start the Game Title animation automatically at game start,
        // assuming it's set to play on Awake.
        // If not, you can trigger it here using gameTitleAnimator.Play("YourAnimationName");

        // Then, start the coroutine to handle the sequence.
        StartCoroutine(HandleIntroSequence());
    }

    private IEnumerator HandleIntroSequence()
    {
        // Wait for the Game Title animation to finish (270ms = 0.27s)
        yield return new WaitForSeconds(0.27f + delayBeforeMenuFade);

        // After the Game Title has finished and the delay, start the Game Menu UI fade-in animation
        gameMenuUIAnimator.Play("MenuFadeIn");
    }
}
