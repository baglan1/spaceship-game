using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rayCastOffset = 2.5f;
    [SerializeField] float detectionDistance = 20f;

    void Update() {
        Pathfinding();
        Move();
    }

    void Turn() {
        Vector3 pos = target.position - transform.position;
        var rotation = Quaternion.LookRotation(pos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move() {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding() {
        var left = transform.position - transform.right * rayCastOffset;
        var right = transform.position + transform.right * rayCastOffset;
        var up = transform.position + transform.up * rayCastOffset;
        var down = transform.position - transform.up * rayCastOffset;

        RaycastHit hit;
        var raycastOffset = Vector3.zero;

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance)) {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance)) {
            raycastOffset -= Vector3.right;
        }

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance)) {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance)) {
            raycastOffset += Vector3.up;
        }

        if (raycastOffset == Vector3.zero) {
            Turn();
        } else {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
    }
}
