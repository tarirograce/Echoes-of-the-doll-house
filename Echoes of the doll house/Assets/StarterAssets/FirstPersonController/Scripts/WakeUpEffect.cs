//written by Tariro Grace
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WakeUpEffect : MonoBehaviour
{
    public Image fadePanel;
    public float fadeSpeed = 1f;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color color = fadePanel.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime * fadeSpeed;
            fadePanel.color = color;
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
    }
}
