using UnityEngine;

public class FinalBossSpawner : MonoBehaviour
{
    public GameObject bossRoom;

    private void OnTriggerEnter(Collider other)
    {
        bossRoom.SetActive(true);
    }
}
