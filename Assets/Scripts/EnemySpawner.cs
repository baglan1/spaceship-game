using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 5f;

    void OnEnable() {
        EventManager.OnStartGame += StartSpawning;
        EventManager.OnPlayerDeath += StopSpawning;
    }

    void OnDisable() {
        EventManager.OnStartGame -= StartSpawning;
        EventManager.OnPlayerDeath -= StopSpawning;
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
