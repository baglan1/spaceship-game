using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CapsuleCollider))]
public class PickUp : MonoBehaviour
{
    static int points = 100;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            PickUpHit();
        }
    }

    void PickUpHit() {
        EventManager.ScorePoints(points);
        EventManager.SpawnPickUp();

        Destroy(gameObject);
    }
}
