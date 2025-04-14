using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] public float respawnDelay = 2f;
    private List<GameObject> currentEnemies = new List<GameObject>();
    private bool isRespawning = false;  
    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        // Check if all enemies are dead
       
        //currentEnemies.RemoveAll(enemy => enemy == null);
      //  if (currentEnemies.Count == 0 && !isRespawning)
       // {
       //     StartCoroutine(RespawnWave());
       // }
    }


    IEnumerator RespawnWave()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);
        SpawnWave();
        isRespawning= false;
    }
    void SpawnWave()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            currentEnemies.Add(enemy);
        }
    }
}
