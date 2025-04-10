using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    public float bulletspeed = 5;
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

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
