using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour
{


    Vector2 movement;
    Vector2 mouseMovement;

    Rigidbody rb; 
    float cameraUpRotation;
    CharacterController controller;

    [SerializeField]
    float speed = 3f;

    [SerializeField]
    float mouseSensitivity = 40;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject PlayerBullet;
    [SerializeField]
    float health = 10;
    [SerializeField]
    float shootCooldown = 0.5f;  // Cooldown duration in seconds
    private AudioSource fireSound;
 

    private float shootCooldownTimer = 0f;
    private bool hasPowerup = false;

    //Jumping
    bool hasJumped = false;
    public bool hasBounce = false;

    float ySpeed = 0;
    [SerializeField]
    float jumpHeight = 1.0f;
    [SerializeField]
    float gravityVal = 9.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        fireSound = GetComponent<AudioSource>();
    }

   

    // Update is called once per frame
    void Update()
    {
       
        float lookX = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float lookY = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= lookY;

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookX);

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        float moveX = movement.x;
        float moveZ = movement.y;
        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);

        //jumping code
        if (hasJumped)
        {
            hasJumped = false;
            ySpeed = jumpHeight;
        }
        ySpeed -= gravityVal * Time.deltaTime;
        actual_movement.y = ySpeed;

        controller.Move(actual_movement * Time.deltaTime * speed);


        if ( health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (shootCooldownTimer > 0)
        {
            shootCooldownTimer -= Time.deltaTime;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBullet>() != null)
        {
            Debug.Log("Bullet hit!");
            health -= 1;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Debug.Log("Laser hit!");
            health -= 2;
        }
        if (other.CompareTag("Drum") )
        {
            Debug.Log("Drum hit!");
            health -= 1;
        }
    }

    
    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }
    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnJump()
    {
        if (controller.isGrounded)
        {
            hasJumped = true;
        }
    }
    void OnAttack()
    {
        if (shootCooldownTimer <= 0f)
        {
            
            Instantiate(PlayerBullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            fireSound.Play();
            shootCooldownTimer = shootCooldown;  // Reset the cooldown timer
        }
    }
    public void AddHealth(float amount)
    {
        health += amount;
        Debug.Log("Health = " + health + amount);
    }

    
    //void OnTriggerEnter(Collider other)
    // {
    //if (other.CompareTag("Powerup"))
    // {
    //   hasPowerup = true;
    //   jumpHeight = 5f; // Increased jump height
    //  Destroy(other.gameObject);

    // }
    //}
}