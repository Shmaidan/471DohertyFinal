using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    public float bulletspeed = 12;
    [SerializeField]
    float lifetime = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletspeed, ForceMode.Impulse); // Impulse for instant velocity
        Destroy(gameObject, lifetime); // Destroy after some time
    }

    // Update is called once per frame

    void Update()
    {


       


    }
}

