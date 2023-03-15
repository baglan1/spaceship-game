using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 5f;

    void OnEnable() {
        EventManager.OnStartGame += StartSpawning;
    }

    void OnDisable() {
        EventManager.OnStartGame -= StartSpawning;
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void StartSpawning() {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning() {
        CancelInvoke();
    }
}
