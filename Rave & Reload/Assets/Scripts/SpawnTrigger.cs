using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject spawner;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameObject.SetActive(true);  // Disable the trigger so it doesn’t fire again
        }
    }
}