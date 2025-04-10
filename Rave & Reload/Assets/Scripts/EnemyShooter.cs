using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject bulletSpawner;
    public float shootingInterval = 3f;
    public float bulletSpeed = 10f;

    private Transform player;
    private float timer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = shootingInterval;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        //rotate firepoint to face player
        Vector3 lookDirection = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        timer -= Time.deltaTime;    
        if (timer <= 0f)
        {
            shootAtPlayer();
            timer = shootingInterval;
        }
    }

    void shootAtPlayer()
    {
        Instantiate(enemyBullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        
    }
}
