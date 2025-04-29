
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 5;
    [SerializeField]
    float speed = 2;
    private Transform player;
   private Rigidbody enemyRb;
    public ParticleSystem particles;
    public AudioClip soundToPlayOnDeath;
    private AudioSource audioSource;
    
    public bool isDead; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(soundToPlayOnDeath, transform.position);
            Instantiate(particles, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }

        //Enemy moves towards player
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 move = transform.position + direction * speed * Time.fixedDeltaTime;

        enemyRb.MovePosition(move);

    }

    //Enemy Death
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
