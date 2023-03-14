using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    AsteroidController asteroidController;

    [SerializeField]
    int numOfAsteroidsOnAnAxis = 10;

    [SerializeField]
    float gridSpacing = 10f;

    // Start is called before the first frame update
    void Start()
    {
        PlaceAsteroids();
    }

    void PlaceAsteroids() {
        for (int x = 0; x < numOfAsteroidsOnAnAxis; x++) {
            for (int y = 0; y < numOfAsteroidsOnAnAxis; y++) {
                for (int z = 0; z < numOfAsteroidsOnAnAxis; z++) {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAsteroid(int x, int y, int z) {
        var asteroidPos = transform.position + new Vector3(x, y, z) * gridSpacing
            + new Vector3(AsteroidOffset(), AsteroidOffset(), AsteroidOffset());

        Instantiate(asteroidController, asteroidPos, Quaternion.identity, transform);
    }

    float AsteroidOffset() {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
