using UnityEngine;

public class HealthBoost : MonoBehaviour
{

    public float healthBoost = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController player = other.GetComponent<FirstPersonController>();
            if (player != null)
            {
                player.AddHealth(healthBoost);
                Destroy(gameObject);
            }
        }
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

