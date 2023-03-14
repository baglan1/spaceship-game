using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 distance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationDamp = 10f;

    Transform _transform;
    Vector3 velocity = Vector3.one;

    void Start() {
        _transform = this.transform;
    }

    void Update() {
        SmoothFollow();
    }

    void SmoothFollow() {
        var toPos = target.position + (target.rotation * distance);
        var currentPos = Vector3.SmoothDamp(_transform.position, toPos, ref velocity, distanceDamp);
        _transform.position = currentPos;

        _transform.LookAt(target, target.up);
    }
}
