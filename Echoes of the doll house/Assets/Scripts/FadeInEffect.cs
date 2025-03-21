//written by Tariro Grace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEffect : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 3f; // Duration of fade-in

    void Start()
    {
        if (fadeCanvasGroup != null)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            Debug.LogError("CanvasGroup not assigned to FadePanel!");
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 0f;
        fadeCanvasGroup.gameObject.SetActive(false); // Disable after fade
    }
}
