using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PrefabsSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] prefabs;
    List<GameObject> availableSpawnPoints = new();
    
    public event Action<GameObject> OnSpawn;
    
    void Start() {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsNails");
        availableSpawnPoints.AddRange(spawnPoints);
    }

    public void SpawnRandomAmount(int amount) {

        List<GameObject> availableSpawnPoints = this.availableSpawnPoints;
        for (int i = 0; i < amount && availableSpawnPoints.Count > 0; i++) {
            int index = Random.Range(0, availableSpawnPoints.Count - 1);
            GameObject spawnPoint = availableSpawnPoints[index];
            Vector3 pos = spawnPoint.transform.position;
            
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
            
            GameObject newPrefab = Instantiate(prefab, pos, Quaternion.identity);
            
            newPrefab.transform.rotation = Quaternion.Euler(-90, 0, 0);
            availableSpawnPoints.RemoveAt(index);
            
            OnSpawn?.Invoke(newPrefab);
        }
        
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointsNails");
        
    }
}
