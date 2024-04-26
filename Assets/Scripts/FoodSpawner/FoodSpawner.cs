using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodSpawner : MonoBehaviour
{

    [Serializable]
    public struct Location
    {
        public int TOTAL_FOOD;
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
    }
    [SerializeField]
    private InventoryItemData[] foodItems;
    public Location[] locations;

    [SerializeField]
    private int numFoodPerDay;

    public void SpawnFood()
    {
        foreach (Location location in locations)
        {
            if (!location.IsMapActive() || location.spawnPositions.Length <= 0)
            {
                continue;
            }
            for (int i = 0; i < numFoodPerDay; i++)
            {
                GameObject foodToSpawn = foodItems[UnityEngine.Random.Range(0, foodItems.Length)].model;
                Instantiate(foodToSpawn, location.GetSpawnPosition());
            }
        }
    }
}
