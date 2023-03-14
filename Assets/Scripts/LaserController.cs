using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class LaserController : MonoBehaviour
{
    [SerializeField] float laserOffTime = .5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;
    LineRenderer lineRenderer;
    Light laserLight;
    bool canFire;

    public float Distance {
        get {
            return maxDistance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();

        lineRenderer.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

    Vector3 CastRay() {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * maxDistance;

        if (Physics.Raycast(transform.position, forward, out hit)) {
            SpawnExplosion(hit.point, hit.transform);
            
            return hit.point;
        }

        return transform.position + transform.forward * maxDistance;
    }

    void SpawnExplosion(Vector3 hitPoint, Transform target = null) {
        var temp = target.GetComponent<Explosion>();
        if (temp is not null) {
            temp.AddForce(hitPoint, transform);
        }
    }

    public void FireLaser() {
        var targetPosition = CastRay();
        FireLaser(targetPosition);
    }

    public void FireLaser(Vector3 targetPosition, Transform target = null) {
        if (canFire) {
            if (target != null)
                SpawnExplosion(targetPosition, target);

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, targetPosition);
            lineRenderer.enabled = true;
            laserLight.enabled = true;

            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);
        }
    }

    void TurnOffLaser() {
        lineRenderer.enabled = false;
        laserLight.enabled = false;
    }

    void CanFire() {
        canFire = true;
    }
}
