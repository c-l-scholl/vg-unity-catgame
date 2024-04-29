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
        public List<Transform> spawnedAtPositions;
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
            spawnableFoodCount -= 1;
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
                Transform spawnSpot = location.GetSpawnPosition();
                Instantiate(foodToSpawn, spawnSpot);
                location.spawnedAtPositions.Add(spawnSpot);
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
                foreach(Transform spawnSpot in location.spawnedAtPositions)
                {
                    Debug.Log(spawnSpot.childCount);
                }
            }
        }
    }



    public int CalculateRemainingFood()
    {
        int remainingFood = 0;
        foreach (Location location in locations)
        {
            if (location.IsMapActive() && location.spawnPositions.Length > 0)
            {
                remainingFood += location.spawnableFoodCount;
            }
        }
        return remainingFood;
    }
}
