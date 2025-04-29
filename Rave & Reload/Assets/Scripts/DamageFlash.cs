using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.5f;
    public Color flashColor = new Color(1, 0, 0, 0.6f); // semi-transparent red

    private float flashTimer;

    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            flashImage.color = Color.Lerp(flashColor, Color.clear, 1 - (flashTimer / flashDuration));
        }
    }

    public void TriggerFlash()
    {
        flashTimer = flashDuration;
        flashImage.color = flashColor;
    }
}