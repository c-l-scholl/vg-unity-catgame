using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;

    public float minSpawnInterval = 0.1f;

    public float maxSpawnInterval = 20f;

    private void Start()
    {
        // Start spawning cars at random intervals
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        // Spawn cars repeatedly
        while (true)
        {
            // Wait for a random interval before spawning the next car
            yield return new WaitForSeconds(Random
                        .Range(minSpawnInterval, maxSpawnInterval));

            // Instantiate a random car prefab at the spawner's position
            Instantiate(SelectACarPrefab(), transform);
        }
    }

    private GameObject SelectACarPrefab()
    {
        // Select a random car prefab from the array
        var randomIndex = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randomIndex];
    }
}
