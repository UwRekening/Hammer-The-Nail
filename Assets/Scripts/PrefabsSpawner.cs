using System;
using System.Collections.Generic;
using New_Scripts;
using UnityEngine;

/// <summary>
/// Spawns prefabs (e.g., nails) at random spawn points marked with SpawnPointIndicator.
/// </summary>
public class PrefabsSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject[] prefabs;

    private GameObject[] spawnPoints;
    private List<GameObject> availableSpawnPoints = new();

    public event Action<GameObject> OnSpawn;

    private void Start()
    {
        // Find all GameObjects in the scene that have a SpawnPointIndicator component
        var indicators = FindObjectsOfType<SpawnPointIndicator>();
        spawnPoints = new GameObject[indicators.Length];

        for (int i = 0; i < indicators.Length; i++)
        {
            spawnPoints[i] = indicators[i].gameObject;
        }

        availableSpawnPoints.AddRange(spawnPoints);
    }

    public void SpawnRandomAmount(int amount)
    {
        if (availableSpawnPoints.Count == 0)
        {
            availableSpawnPoints.AddRange(spawnPoints);
        }

        for (int i = 0; i < amount && availableSpawnPoints.Count > 0; i++)
        {
            int spawnIndex = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
            GameObject spawnPoint = availableSpawnPoints[spawnIndex];

            Vector3 position = spawnPoint.transform.position;
            GameObject prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
            GameObject spawnedObject = Instantiate(prefab, position, Quaternion.Euler(-90f, 0f, 0f));

            availableSpawnPoints.RemoveAt(spawnIndex);
            OnSpawn?.Invoke(spawnedObject);
        }
    }
}