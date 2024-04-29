using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodSpawner : MonoBehaviour
{

    [Serializable]
    public struct Location
    {
        public int spawnableFoodCount;
        public GameObject mapSection;
        public Transform[] spawnPositions;
        public Transform GetSpawnPosition()
        {
            int i = UnityEngine.Random.Range(0, spawnPositions.Length);
            return spawnPositions[i];
        }
        public bool IsMapActive()
        {
            return mapSection.activeSelf;
        }
        public void DecrementSpawnFoodCount()
        {
            spawnableFoodCount--;
        }
    }
    [SerializeField]
    private InventoryItemData[] foodItems;
    public Location[] locations;

    public void SpawnFood()
    {
        foreach (Location location in locations)
        {
            if (!location.IsMapActive() || location.spawnPositions.Length <= 0)
            {
                continue;
            }
            for (int i = 0; i < location.spawnableFoodCount; i++)
            {
                GameObject foodToSpawn = foodItems[UnityEngine.Random.Range(0, foodItems.Length)].model;
                Instantiate(foodToSpawn, location.GetSpawnPosition());
            }
        }
    }

    public void DecrementFoodCount()
    {
        foreach (Location location in locations)
        {
            if (location.IsMapActive() && location.spawnPositions.Length > 0)
            {
                location.DecrementSpawnFoodCount();
            }
        }
    }
}
