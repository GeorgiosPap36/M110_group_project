using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeIn : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup;
    public float fadeDuration = 2.0f;
    private float currentLerpTime = 0;

    void Update()
    {
        // Increment the time
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > fadeDuration) {
            currentLerpTime = fadeDuration;
        }

        // Calculate the lerp value
        float lerpValue = currentLerpTime / fadeDuration;
        uiCanvasGroup.alpha = Mathf.Lerp(0, 1, lerpValue);
    }
}
