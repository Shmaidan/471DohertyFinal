using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TurretHealth : MonoBehaviour
{
    [SerializeField]
    float health = 5;
    private Rigidbody enemyRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBullet>() != null)
        {
            Debug.Log("Bullet hit!");
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}
