//written by Tariro Grace
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlay : MonoBehaviour
{
    public Image bloodOverlay;
    public float fadeSpeed = 2f;

    private void Update()
    {
        if (bloodOverlay.color.a > 0)
        {
            Color tempColor = bloodOverlay.color;
            tempColor.a -= fadeSpeed * Time.deltaTime;
            bloodOverlay.color = tempColor;
        }
    }

    public void ShowBlood()
    {
        Color tempColor = bloodOverlay.color;
        tempColor.a = 0.7f; // make blood flash visible
        bloodOverlay.color = tempColor;
    }
}
