using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Camera1;
    public GameObject Camera2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room1"))
        {
            Camera1.SetActive(false);
        }
    }
}

