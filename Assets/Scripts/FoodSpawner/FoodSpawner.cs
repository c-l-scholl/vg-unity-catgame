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
            return spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)];
        }
        public bool IsMapActive()
        {
            return mapSection.activeSelf;
        }
        public void DecreaseSpawnFoodCount(int amount)
        {
            int foodLeft = spawnableFoodCount - amount;
            spawnableFoodCount = foodLeft > 0 ? foodLeft : 0;
        }   
    }

    [SerializeField]
    private InventoryItemData[] foodItems;
    public Location[] locations;

    [SerializeField]
    private int numFoodToSpawn;
    private HashSet<Transform> spawnSpots = new HashSet<Transform>();

    public void SpawnFood()
    {
        foreach (Location location in locations)
        {
            if (!location.IsMapActive() || location.spawnPositions.Length <= 0)
            {
                continue;
            }
            for (int i = 0; i < numFoodToSpawn; i++)
            {
                GameObject foodToSpawn = foodItems[UnityEngine.Random.Range(0, foodItems.Length)].model;
                Transform spawnSpot = location.GetSpawnPosition();
                while (spawnSpots.Contains(spawnSpot))
                {
                    spawnSpot = location.GetSpawnPosition();
                }
                Instantiate(foodToSpawn, spawnSpot);
                spawnSpots.Add(spawnSpot);
            }
        }
    }

    public void DecrementFoodCount()
    {
        for (int i = 0; i < locations.Length; i++)
        {
            if (locations[i].IsMapActive() && locations[i].spawnPositions.Length > 0)
            {
                int eatenFood = 0;
                foreach(Transform spawnSpot in spawnSpots)
                {
                    if (spawnSpot.childCount == 0)
                    {
                        eatenFood++;
                    }
                }
                locations[i].DecreaseSpawnFoodCount(eatenFood);
            }
        }
        spawnSpots.Clear();
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
