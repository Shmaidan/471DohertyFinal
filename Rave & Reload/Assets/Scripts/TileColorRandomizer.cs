using System.Collections;
using UnityEngine;

public class TileColorRandomizer : MonoBehaviour
{
    public Transform tilesParent; 
    public float interval = 2f;    

    private Renderer[] tileRenderers;

    private void Start()
    {
        
        tileRenderers = tilesParent.GetComponentsInChildren<Renderer>();
        StartCoroutine(RandomizeColors());
    }

    private IEnumerator RandomizeColors()
    {
        while (true)
        {
            foreach (Renderer rend in tileRenderers)
            {
                rend.material.color = new Color(Random.value, Random.value, Random.value);
            }
            yield return new WaitForSeconds(interval);
        }
    }
}