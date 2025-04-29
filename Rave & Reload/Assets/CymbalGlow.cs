using UnityEngine;

public class CymbalGlow : MonoBehaviour
{
    public Color baseColor = Color.cyan; // The color of the glow
    public float pulseSpeed = 2f;         // How fast it pulses
    public float minIntensity = 0.5f;     // Minimum glow intensity
    public float maxIntensity = 2f;       // Maximum glow intensity

    private Material material;
    private Color emissionColor;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float emission = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        emissionColor = baseColor * Mathf.LinearToGammaSpace(emission);
        material.SetColor("_EmissionColor", emissionColor);
    }
}
