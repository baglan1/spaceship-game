using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 distance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;

    Transform _transform;
    Vector3 velocity = Vector3.one;

    void Start() {
        _transform = this.transform;
    }

    void Update() {
        if (!FindTarget())
            return;

        SmoothFollow();
    }

    void SmoothFollow() {
        var toPos = target.position + (target.rotation * distance);
        var currentPos = Vector3.SmoothDamp(_transform.position, toPos, ref velocity, distanceDamp);
        _transform.position = currentPos;

        _transform.LookAt(target, target.up);
    }

    bool FindTarget() {
        if (target == null) {
            var playerGo = GameObject.FindGameObjectWithTag("Player");

            if (playerGo != null)
                target = playerGo.transform;
        }

        if (target == null) return false;

        return true;
    }
}
