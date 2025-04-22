using UnityEngine;

public class EmissionPulse : MonoBehaviour
{
    public Color baseColor = Color.magenta;
    public float pulseSpeed = 2f;
    public float pulseStrength = 2f;

    private Material mat;
    private Color emissionColor;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float emission = Mathf.PingPong(Time.time * pulseSpeed, 1.0f) * pulseStrength;
        emissionColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", emissionColor);
    }
}
