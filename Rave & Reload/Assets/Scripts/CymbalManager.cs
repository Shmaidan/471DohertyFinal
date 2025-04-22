using UnityEngine;

public class CymbalManager : MonoBehaviour
{
    public GameObject vanishWall;
    public float cymbalsAlive;

    void Start()
    {
        // Set initial count by how many cymbals exist in the scene
        cymbalsAlive = GameObject.FindGameObjectsWithTag("Cymbal").Length;
        Debug.Log("Cymbals in room: " + cymbalsAlive);
    }

    public void CymbalBroken()
    {
        cymbalsAlive -= 1;
        Debug.Log("Cymbal destroyed, remaining: " + cymbalsAlive);

        if (cymbalsAlive <= 0)
        {
            Debug.Log("All cymbals broken — vanishing wall!");
            vanishWall.SetActive(false);
        }
    }
}
