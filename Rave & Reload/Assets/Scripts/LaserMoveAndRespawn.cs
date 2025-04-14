using UnityEngine;

public class LaserMoveAndRespawn : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public LaserSpawnManager manager;

    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = (endPosition - startPosition).normalized;

       
        transform.position = startPosition;
    }

    void Update()
    {
        
        transform.position += moveDirection * speed * Time.deltaTime;

        
        if (Vector3.Distance(transform.position, endPosition) < 0.1f)
        {
            if (manager != null)
            {
                manager.LaserReachedEnd(gameObject);
            }
            else
            {
                Debug.LogWarning("Laser has no manager assigned!");
                Destroy(gameObject);
            }
        }
    }
}