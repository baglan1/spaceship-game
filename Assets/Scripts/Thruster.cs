using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    TrailRenderer trailRenderer;
    Light thrusterLight;

    void Start() {
        trailRenderer = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();

        thrusterLight.intensity = 0f;
    }

    public void SetInstensity(float intensity) {
        thrusterLight.intensity = intensity;
    }
}
