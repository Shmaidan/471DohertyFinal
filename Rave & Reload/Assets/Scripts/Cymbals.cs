using UnityEngine;
using UnityEngine.Audio;

public class Cymbals : MonoBehaviour
{
    public CymbalManager manager;
    public AudioClip woosh;
    

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            AudioSource.PlayClipAtPoint(woosh, transform.position);
            Debug.Log("Cymbal hit!");
            manager.CymbalBroken();
            Destroy(gameObject);
        }
    }
}