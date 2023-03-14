using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] LaserController laser;

    Vector3 hitPosition;

    void Update() {
        if (!FindTarget())
            return;

        if (InFront() && HaveInLineSight()) {
            FireLaser();
        }
    }

    bool InFront() {
        var directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90f && Mathf.Abs(angle) < 270f) {
            return true;
        }

        return false;
    }

    bool HaveInLineSight() {
        RaycastHit hit;
        var direction = target.position - transform.position;

        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance)) {
            if (hit.transform.CompareTag("Player")) {
                hitPosition = hit.point;

                return true;
            }
        }

        return false;
    }

    void FireLaser() {
        laser.FireLaser(hitPosition, target);
    }

    bool FindTarget() {
        if (target == null) {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target == null) return false;

        return true;
    }
}
