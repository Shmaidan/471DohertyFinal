using UnityEngine;
using UnityEngine.SceneManagement;

public class DrumRoutes : MonoBehaviour
{
    public float health = 1f;
    private Rigidbody rb;
    [SerializeField] GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    [SerializeField] float speed = 3.0f;

    void Start()
    {
        target = route[routeIndex];
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveTo(target);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            routeIndex += 1;
            if (routeIndex >= route.Length)
                routeIndex = 0;

            target = route[routeIndex];
        }
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    
}

