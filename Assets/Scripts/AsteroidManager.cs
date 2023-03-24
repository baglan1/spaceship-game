using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] AsteroidController asteroidController;
    [SerializeField] int numOfAsteroidsOnAnAxis = 10;
    [SerializeField] float gridSpacing = 10f;
    [SerializeField] GameObject pickUpPrefab;

    List<AsteroidController> asteroids = new List<AsteroidController>();

    void OnEnable() {
        EventManager.OnStartGame += PlaceAsteroids;
        EventManager.OnPlayerDeath += DestroyAsteroids;
        EventManager.OnSpawnPickUp += InstantiatePickUp;
    }

    void OnDisable() {
        EventManager.OnStartGame -= PlaceAsteroids;
        EventManager.OnPlayerDeath -= DestroyAsteroids;
        EventManager.OnSpawnPickUp -= InstantiatePickUp;
    }

    void PlaceAsteroids() {
        for (int x = 0; x < numOfAsteroidsOnAnAxis; x++) {
            for (int y = 0; y < numOfAsteroidsOnAnAxis; y++) {
                for (int z = 0; z < numOfAsteroidsOnAnAxis; z++) {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }

        InstantiatePickUp();
    }

    void InstantiateAsteroid(int x, int y, int z) {
        var asteroidPos = transform.position + new Vector3(x, y, z) * gridSpacing
            + new Vector3(AsteroidOffset(), AsteroidOffset(), AsteroidOffset());

        var asteroid = Instantiate(asteroidController, asteroidPos, Quaternion.identity, transform);
        asteroids.Add(asteroid);
    }

    void InstantiatePickUp() {
        var rnd = Random.Range(0, asteroids.Count);

        Instantiate(pickUpPrefab, asteroids[rnd].transform.position, Quaternion.identity);

        Destroy(asteroids[rnd].gameObject);
        asteroids.RemoveAt(rnd);
    }

    float AsteroidOffset() {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }

    void DestroyAsteroids() {
        foreach (var ast in asteroids) {
            ast.SelfDestruct();
        }
    }
}
