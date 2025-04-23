using Unity.VisualScripting;
using UnityEngine;

public class Piano : MonoBehaviour
{
    [SerializeField] float health = 5;
    private Rigidbody enemyRb;
    public ParticleSystem particles;
    public AudioSource deathSound;
    public bool isVulnerable = false;
    public GameObject offLasers;

    private BoxCollider boxCol;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();

        // Start with collider disabled
        boxCol.enabled = false;
    }

    void Update()
    {
        GameObject[] weakPoints = GameObject.FindGameObjectsWithTag("Weak");

        if (weakPoints.Length == 0 && !isVulnerable)
        {
            BecomeVulnerable();
        }

        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isVulnerable && other.GetComponent<PlayerBullet>() != null)
        {
            Debug.Log("Bullet hit!");
            health -= 1;
            Destroy(other.gameObject);
            offLasers.SetActive(false); 
        }
    }

    void BecomeVulnerable()
    {
        isVulnerable = true;
        Debug.Log("Piano is now vulnerable");

        // Enable collider when vulnerable
        if (boxCol != null)
        {
            boxCol.enabled = true;
        }
    }
}