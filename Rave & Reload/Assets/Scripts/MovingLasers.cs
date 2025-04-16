using UnityEngine;

public class MovingLasers : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float moveHeight = 1f;
    private Vector3 startPosition;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveHeight;
        rb.MovePosition(new Vector3(transform.position.x, newY, transform.position.z));
    }
}
