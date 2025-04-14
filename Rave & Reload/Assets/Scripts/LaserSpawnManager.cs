using UnityEngine;

public class LaserSpawnManager : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform spawnPoint;
    public Transform endPoint;
    public float spawnInterval = 2f;
    public int maxLasers = 5;

    private int currentLaserCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnLaser), 0f, spawnInterval);
    }

    void SpawnLaser()
    {
        if (currentLaserCount < maxLasers)
        {
            GameObject newLaser = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);
            LaserMoveAndRespawn laserScript = newLaser.GetComponent<LaserMoveAndRespawn>();

            if (laserScript != null)
            {
                laserScript.startPosition = spawnPoint.position;
                laserScript.endPosition = endPoint.position;
                laserScript.manager = this; // Assign manager reference
            }

            currentLaserCount++;
        }
    }

    public void LaserReachedEnd(GameObject laser)
    {
        Destroy(laser);
        currentLaserCount--;
    }
}