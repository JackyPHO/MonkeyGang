using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab; // Drag the orb prefab here
    public int orbCount = 10; // Number of orbs to spawn
    public GameObject healthOrbPrefab; 
    public int healthOrbCount = 5; 
    public GameObject speedOrbPrefab; 
    public int speedOrbCount = 5;
    public Vector3 spawnAreaSize = new Vector3(40, 0, 40); // X and Z define the floor area
    public float spawnHeight = 1.0f; // Height at which orbs will spawn

    void Start()
    {
        SpawnOrbs();
        SpawnHealthOrbs();
        SpawnSpeedOrbs();
    }

    void SpawnOrbs()
    {
        for (int i = 0; i < orbCount; i++)
        {
            // Random position within the spawn area
            float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

            // Spawn the orb
            Instantiate(orbPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnHealthOrbs()
    {
        for (int i = 0; i < healthOrbCount; i++)
        {
            float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

            Instantiate(healthOrbPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnSpeedOrbs()
    {
        for (int i = 0; i < speedOrbCount; i++)
        {
            float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

            Instantiate(speedOrbPrefab, spawnPosition, Quaternion.identity);
        }
    }
}