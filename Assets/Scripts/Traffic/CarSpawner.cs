using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;

    public bool goesRight;

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

    public void MoveWithMapUnlocks()
    {
        if (goesRight)
        {
            transform.position = new Vector3(-76f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(45f, transform.position.y, transform.position.z);
        }
    }
}
